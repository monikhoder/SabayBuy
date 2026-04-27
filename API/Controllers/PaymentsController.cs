using Api.Helpers;
using API.Dtos;
using API.Helpers;
using API.SignalR;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

namespace API.Controllers;

public class PaymentsController(
        IPaymentService paymentService,
        ICartService cartService,
        IUnitOfWork unit,
        IHubContext<NotificationHub> hubContext,
        IMapper mapper,
        UserManager<AppUser> userManager
) : BaseApiController
{
    [Authorize]
    [HttpPost("checkout-v2")]
    public async Task<ActionResult> CheckoutV2([FromBody] CreateOrderPaymentDto checkoutDto)
    {
        var email = User.GetEmail();
        var user = await userManager.GetUserByEmail(User);

        var cart = await cartService.GetCardAsync(checkoutDto.CartId);
        if (cart == null) return BadRequest("Cart not found");

        var items = new List<OrderItem>();

        foreach (var item in cart.Items)
        {
            if (!Guid.TryParse(item.ProductId, out var productId))
            {
                return BadRequest($"Invalid product id in cart: {item.ProductId}");
            }

            if (!Guid.TryParse(item.ProductVariantId, out var productVariantId))
            {
                return BadRequest($"Invalid product variant id in cart: {item.ProductVariantId}");
            }

            var product = await unit.Repository<Product>().GetByIdAsync(productId);
            if (product == null || !product.IsActive)
            {
                return BadRequest($"Product with id {item.ProductId} not found or inactive");
            }

            var productVariant = await unit.Repository<ProductVariant>().GetByIdAsync(productVariantId);
            if (productVariant == null || !productVariant.IsActive)
            {
                return BadRequest($"Product variant with id {item.ProductVariantId} not found or inactive");
            }

            if (item.Quantity <= 0) return BadRequest("Order item quantity must be greater than zero");
            if (productVariant.StockQuantity < item.Quantity)
            {
                return BadRequest($"Insufficient stock for {product.ProductName} ({item.ProductVariantName}). Available: {productVariant.StockQuantity}");
            }

            items.Add(new OrderItem
            {
                ItemOrdered = new ProductItemOrdered
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    ProductVariantId = productVariant.Id,
                    VariantName = item.ProductVariantName,
                    ImageUrl = item.ImageUrl
                },
                Price = productVariant.Price,
                Quantity = item.Quantity
            });

            productVariant.StockQuantity -= item.Quantity;
            unit.Repository<ProductVariant>().Update(productVariant);
        }

        var deliveryMethod = await unit.Repository<DeliveryMethod>().GetByIdAsync(checkoutDto.DeliveryMethodId);
        if (deliveryMethod == null) return BadRequest("Delivery method not found");

        var order = new Order
        {
            BuyerEmail = email,
            ShippingAddress = checkoutDto.ShippingAddress,
            DeliveryMethod = deliveryMethod,
            OrderItems = items,
            Subtotal = items.Sum(x => x.Price * x.Quantity),
            PaymentMethod = checkoutDto.PaymentMethod,
            Source = OrderSource.Web,
            Status = OrderStatus.Pending
        };

        unit.Repository<Order>().Add(order);
        if (!await unit.Complete())
        {
            return BadRequest("Problem creating order");
        }

        if (checkoutDto.PaymentMethod == PaymentMethod.cod)
        {
            return Ok(mapper.Map<OrderDto>(order));
        }

        if (checkoutDto.PaymentMethod != PaymentMethod.cod)
        {
            var total = order.Subtotal + deliveryMethod.Price;
            PaymentResult? payment;

            try
            {
                payment = await paymentService.CreatePaymentForOrderAsync(checkoutDto.PaymentMethod, total, user, order.Id);
            }
            catch (NotSupportedException ex)
            {
                await MarkPaymentFailedAndReturnStock(order);
                return BadRequest(ex.Message);
            }

            if (payment == null)
            {
                await MarkPaymentFailedAndReturnStock(order);
                return BadRequest("Problem creating payment");
            }

            order.PaymentIntentId = payment.PaymentIntentId;
            unit.Repository<Order>().Update(order);

            if (!await unit.Complete())
            {
                return BadRequest("Problem saving payment intent");
            }

            return Ok(new
            {
                order = mapper.Map<OrderDto>(order),
                payment = payment.PaymentResponse
            });
        }

        return BadRequest("Payment method not supported");
    }

    private async Task MarkPaymentFailedAndReturnStock(Order order)
    {
        order.Status = OrderStatus.PaymentFailed;
        await ReturnProductsToStock(order);
        unit.Repository<Order>().Update(order);
        await unit.Complete();
    }

    private async Task ReturnProductsToStock(Order order)
    {
        foreach (var orderItem in order.OrderItems)
        {
            var productVariant = await unit.Repository<ProductVariant>()
                .GetByIdAsync(orderItem.ItemOrdered.ProductVariantId);

            if (productVariant == null) continue;

            productVariant.StockQuantity += orderItem.Quantity;
            unit.Repository<ProductVariant>().Update(productVariant);
        }
    }

    [HttpPost("webhook/aba")]
    public async Task<IActionResult> AbaWebhook([FromQuery] string tran_id)
    {
        if (string.IsNullOrEmpty(tran_id))
        {
            return BadRequest("Invalid transaction ID");
        }

        var jsonString = await paymentService.VerifyAbaPaymentAsync(tran_id);
       
        if (string.IsNullOrEmpty(jsonString))
        {
            return BadRequest("No response from ABA");
        }

        try
        {
            var responseObj = AbaPaymentResponse.FromJson(jsonString);
            //set payment approved for testes only
            responseObj.AbaData.PaymentStatusCode = 0;
            responseObj.AbaData.PaymentStatus = "Approved";
            if (responseObj != null &&
                responseObj.AbaData?.PaymentStatusCode == 0)
            {
                // Get the amount from ABA response
                decimal abaAmount = responseObj.AbaData?.TotalAmount ?? 0;

                //Get Order
                var spec = new OrderByPaymentIntentIdSpecification(tran_id);
                var order = await unit.Repository<Order>().GetEntityWithSpec(spec);

                if (order == null) return NotFound("Order not found");

                decimal orderTotal = order.Subtotal + (order.DeliveryMethod?.Price ?? 0);

                order.Status = OrderStatus.PaymentReceived;
                unit.Repository<Order>().Update(order);
                await unit.Complete();

                string buyerEmail = order.BuyerEmail;

                //send notification to buyer
                if (!string.IsNullOrEmpty(buyerEmail))
                {
                    var connectionId = NotificationHub.getConnectionIdbyEmail(buyerEmail);

                    if (!string.IsNullOrEmpty(connectionId))
                    {
                        await hubContext.Clients.Client(connectionId).SendAsync("PaymentReceived", mapper.Map<OrderDto>(order));
                    }
                }


                return Ok(responseObj);
            }

            return BadRequest("Payment verification failed or not approved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Webhook Error: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }

    }


    // Get all delivery methods
    [HttpGet("delivery-methods")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
    {
        var deliveryMethods = await unit.Repository<DeliveryMethod>().ListAllAsync();
        return Ok(deliveryMethods);
    }

    //Get delivery method by available zip code
    [HttpGet("delivery-methods/{zipCode}")]
    public async Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethodsByZipCode(string zipCode)
    {
        if (string.IsNullOrWhiteSpace(zipCode) || zipCode.Length < 2)
        {
            return BadRequest("Zip code must be at least 2 characters.");
        }

        var deliveryMethods = await unit.Repository<DeliveryMethod>().ListAllAsync();
        string firstTwoDigits = zipCode.Substring(0, 2);
        return Ok(deliveryMethods.Where(dm => dm.AvailableZipcodes.Contains(firstTwoDigits)).ToList());
    }
}
