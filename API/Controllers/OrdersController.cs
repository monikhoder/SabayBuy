using System.Security.Claims;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController(ICartService cartService, IUnitOfWork unitOfWork, IMapper mapper) : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(CreateOrderDto orderDto)
        {
            var email = User.GetEmail();
            var cart = await cartService.GetCardAsync(orderDto.CartId);
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

                var productItems = await unitOfWork.Repository<Product>().GetByIdAsync(productId);
                if (productItems == null) return BadRequest($"Product with id {item.ProductId} not found");
                var productVariant = await unitOfWork.Repository<ProductVariant>().GetByIdAsync(productVariantId);
                if (productVariant == null) return BadRequest($"Product variant with id {item.ProductVariantId} not found");
                var itemOrdered = new ProductItemOrdered
                {
                    ProductId = productItems.Id,
                    ProductName = productItems.ProductName,
                    ProductVariantId = productVariant.Id,
                    VariantName = item.ProductVariantName,
                    ImageUrl = item.ImageUrl
                };
                var orderItem = new OrderItem
                {
                    ItemOrdered = itemOrdered,
                    Price = productVariant.Price,
                    Quantity = item.Quantity
                };
                items.Add(orderItem);
            }
            var deliveryMethod = await unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(orderDto.DeliveryMethodId);
            if (deliveryMethod == null) return BadRequest("Delivery method not found");

            var order = new Order
            {
                BuyerEmail = email,
                OrderDate = DateTime.UtcNow,
                ShippingAddress = orderDto.ShippingAddress,
                DeliveryMethod = deliveryMethod,
                OrderItems = items,
                Subtotal = items.Sum(x => x.Price * x.Quantity),
                PaymentMethod = orderDto.PaymentMethod,
                PaymentIntentId = orderDto.PaymentIntentId
            };

            unitOfWork.Repository<Order>().Add(order);
            if (await unitOfWork.Complete())
            {
                //remove stock
                foreach (var item in items)
                {
                    var productVariant = await unitOfWork.Repository<ProductVariant>().GetByIdAsync(item.ItemOrdered.ProductVariantId);
                    if (productVariant != null)
                    {
                        productVariant.StockQuantity -= item.Quantity;
                        unitOfWork.Repository<ProductVariant>().Update(productVariant);
                    }
                }
                return Ok(mapper.Map<OrderDto>(order));
            }

            return BadRequest("Problem creating order");
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrdersForUser(
            [FromQuery] OrderSpecParams specParams)
        {
            var spec = new OrderSpecification(User.GetEmail(), specParams);
            return await CreatePageResult<Order, OrderDto>(unitOfWork.Repository<Order>(), spec, specParams.PageIndex, specParams.PageSize, mapper);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderByIdForUser(Guid id)
        {
            //Get User Role
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            if(userRole!.ToLower() == "admin" || userRole!.ToLower() == "seller")
            {
               var spec = new OrderSpecification(id);
               return await GetByIdResult<Order, OrderDto>(unitOfWork.Repository<Order>(), spec, mapper);
            }
            var userspec = new OrderSpecification(id, User.GetEmail());
            return await GetByIdResult<Order, OrderDto>(unitOfWork.Repository<Order>(), userspec, mapper);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDto>> UpdateOrderStatus(Guid id, [FromQuery] OrderStatus orderstatus)
        {
            var email = User.GetEmail();
            var spec = new OrderSpecification(id, email);
            var order = await unitOfWork.Repository<Order>().GetEntityWithSpec(spec);

            if(order == null) return BadRequest("Order not found or unauthorized");

            if (!Enum.IsDefined(typeof(OrderStatus), orderstatus))
                return BadRequest("Invalid status value");

            switch (orderstatus)
            {
                case OrderStatus.Cancelled:
                    if(order.Status == OrderStatus.Pending || order.Status == OrderStatus.OrderConfirm || order.Status == OrderStatus.PaymentReceived || order.Status == OrderStatus.PaymentFailed)
                    {
                        order.Status = orderstatus;
                        await ReturnProductsToStock(order);
                        //if payment received will call refund here
                    }
                    else
                    {
                        return BadRequest($"Order cannot be cancelled at {order.Status}");
                    }
                    break;

                case OrderStatus.ReceivedOrder:
                    if(order.Status == OrderStatus.Delivered)
                    {
                        order.Status = orderstatus;
                    }
                    else
                    {
                        return BadRequest("Order must be delivered before marking as received");
                    }
                    break;

                default:
                    return BadRequest("Status not supported for client update");
            }

            unitOfWork.Repository<Order>().Update(order);
            if(await unitOfWork.Complete())
            {
                return Ok($"Order status updated to {order.Status}");
            }

            return BadRequest("Failed to update status");
        }

        private async Task ReturnProductsToStock(Order order)
        {
            if (order.OrderItems == null || !order.OrderItems.Any())
                return;

            foreach (var orderItem in order.OrderItems)
            {
                var productVariant = await unitOfWork.Repository<ProductVariant>()
                    .GetByIdAsync(orderItem.ItemOrdered.ProductVariantId);

                if (productVariant != null)
                {
                    productVariant.StockQuantity += orderItem.Quantity;
                    unitOfWork.Repository<ProductVariant>().Update(productVariant);
                }
            }
        }
    }
}
