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
                var productItems = await unitOfWork.Repository<Product>().GetByIdAsync(Guid.Parse(item.ProductId));
                if (productItems == null) return BadRequest($"Product with id {item.ProductId} not found");
                var productVariant = await unitOfWork.Repository<ProductVariant>().GetByIdAsync(Guid.Parse(item.ProductVariantId));
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
                Subtotal = items.Sum(x => x.Price * x.Quantity) + deliveryMethod.Price,
                PaymentMethod = orderDto.PaymentMethod,
                PaymentIntentId = orderDto.PaymentIntentId
            };

            unitOfWork.Repository<Order>().Add(order);
            if (await unitOfWork.Complete())
            {
                return Ok(order);
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
            var spec = new OrderSpecification(id, User.GetEmail());
            return await GetByIdResult<Order, OrderDto>(unitOfWork.Repository<Order>(), spec, mapper);
        }
    }
}
