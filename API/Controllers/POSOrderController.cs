using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "Admin,Seller")]
public class POSOrderController(
    IUnitOfWork unit,
    IPaymentService paymentService,
    IMapper mapper,
    UserManager<AppUser> userManager) : BaseApiController
{
    [HttpPost]
    [HttpPost("/api/pos/orders")]
    public async Task<ActionResult> CreateOrder(CreatePOSOrderDto orderDto)
    {
        var cashier = await userManager.GetUserByEmail(User);
        var items = new List<OrderItem>();

        foreach (var item in orderDto.Items)
        {
            var variantSpec = new ProductVariantSpecification(item.ProductVariantId, true);
            var productVariant = await unit.Repository<ProductVariant>().GetEntityWithSpec(variantSpec);
            if (productVariant == null || !productVariant.IsActive)
            {
                return BadRequest($"Product variant with id {item.ProductVariantId} not found or inactive");
            }

            var product = await unit.Repository<Product>().GetByIdAsync(productVariant.ProductId);
            if (product == null || !product.IsActive)
            {
                return BadRequest($"Product for variant {item.ProductVariantId} not found or inactive");
            }

            if (item.Quantity <= 0)
            {
                return BadRequest("Order item quantity must be greater than zero");
            }

            if (productVariant.StockQuantity < item.Quantity)
            {
                return BadRequest($"Insufficient stock for {product.ProductName}. Available: {productVariant.StockQuantity}");
            }

            items.Add(new OrderItem
            {
                ItemOrdered = new ProductItemOrdered
                {
                    ProductId = product.Id,
                    ProductName = product.ProductName,
                    ProductVariantId = productVariant.Id,
                    VariantName = GetVariantName(productVariant),
                    ImageUrl = productVariant.ImageUrl ?? product.BaseImageUrl ?? string.Empty
                },
                Price = productVariant.Price,
                Quantity = item.Quantity
            });

            productVariant.StockQuantity -= item.Quantity;
            unit.Repository<ProductVariant>().Update(productVariant);
        }

        var deliveryMethod = await GetPOSDeliveryMethod(orderDto.DeliveryMethodId);
        if (deliveryMethod == null)
        {
            return BadRequest("Delivery method not found. Provide a valid deliveryMethodId or create a zero-price POS delivery method.");
        }

        var order = new Order
        {
            BuyerEmail = cashier.Email ?? User.GetEmail(),
            ShippingAddress = CreatePOSShippingAddress(orderDto),
            DeliveryMethod = deliveryMethod,
            OrderItems = items,
            Subtotal = items.Sum(x => x.Price * x.Quantity),
            PaymentMethod = orderDto.PaymentMethod,
            Source = OrderSource.POS,
            Status = OrderStatus.Completed
        };

        unit.Repository<Order>().Add(order);
        if (!await unit.Complete())
        {
            return BadRequest("Problem creating POS order");
        }

        if (orderDto.PaymentMethod == PaymentMethod.cod)
        {
            return Ok(mapper.Map<OrderDto>(order));
        }

        var total = order.Subtotal + deliveryMethod.Price;
        PaymentResult? payment;

        try
        {
            payment = await paymentService.CreatePaymentForOrderAsync(orderDto.PaymentMethod, total, cashier, order.Id);
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

    private async Task<DeliveryMethod?> GetPOSDeliveryMethod(Guid? deliveryMethodId)
    {
        if (deliveryMethodId.HasValue)
        {
            return await unit.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId.Value);
        }

        var deliveryMethods = await unit.Repository<DeliveryMethod>().ListAllAsync();
        return deliveryMethods.FirstOrDefault(x =>
                x.ShortName.Equals("Store-Pickup", StringComparison.OrdinalIgnoreCase))
            ?? deliveryMethods.FirstOrDefault(x => x.Price == 0);
    }

    private static ShippingAddress CreatePOSShippingAddress(CreatePOSOrderDto orderDto)
    {
        return new ShippingAddress
        {
            FullName = string.IsNullOrWhiteSpace(orderDto.CustomerName) ? "Walk-in Customer" : orderDto.CustomerName,
            Line1 = "POS Counter",
            PhoneNumber = orderDto.CustomerPhone,
            City = "POS",
            State = "POS",
            ZipCode = "00000",
            Country = "Cambodia"
        };
    }

    private static string GetVariantName(ProductVariant productVariant)
    {
        var variantName = string.Join(" / ",
            productVariant.Attributes.Select(x => $"{x.AttributeName}: {x.AttributeValue}"));

        return string.IsNullOrWhiteSpace(variantName) ? productVariant.Sku : variantName;
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
}
