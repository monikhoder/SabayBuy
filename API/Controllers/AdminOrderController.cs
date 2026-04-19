using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Core.Specifications;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Admin,Seller")]
    public class AdminOrderController(IUnitOfWork unitOfWork, IMapper mapper) : BaseApiController
    {
        // GET: api/AdminOrder
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrders(
            [FromQuery] OrderSpecParams specParams)
        {
            var spec = new OrderSpecification(specParams);
            return await CreatePageResult<Order, OrderDto>(unitOfWork.Repository<Order>(), spec, specParams.PageIndex, specParams.PageSize, mapper);
        }

        // GET: api/AdminOrder/{Id}
        [HttpGet("{id}")]
         public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
        {
            var spec = new OrderSpecification(id);
            return await GetByIdResult<Order, OrderDto>(unitOfWork.Repository<Order>(), spec, mapper);
        }
        //PUT: api/adminorder/{Id}
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderDto>> UpdateOrderStatus(Guid id, [FromQuery] OrderStatus orderstatus)
        {
            // Load order with all necessary includes
            var spec = new OrderSpecification(id);
            var order = await unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
            if(order == null) return BadRequest("Order Not found");
            if(order.Status == orderstatus)
            {
                return BadRequest("Same Status");
            }

            // Ensure the received value is a defined enum value
            if (!Enum.IsDefined(typeof(OrderStatus), orderstatus))
                return BadRequest("Invalid status value");

            switch (orderstatus)
            {
                case OrderStatus.OrderConfirm :
                     // COD orders can be confirmed from Pending
                    if (order.PaymentMethod == PaymentMethod.cod && order.Status == OrderStatus.Pending)
                    {
                        order.Status = orderstatus;
                    }
                    // Online payments require PaymentReceived status
                    else if (order.PaymentMethod != PaymentMethod.cod && order.Status == OrderStatus.PaymentReceived)
                    {
                        order.Status = orderstatus;
                    }
                    else
                    {
                        return BadRequest($"Cannot confirm order from {order.Status} with payment method {order.PaymentMethod}");
                    }
                    break;
                case OrderStatus.Shipped :
                    if(order.Status == OrderStatus.OrderConfirm)
                    {
                         order.Status = orderstatus;
                    }
                    else
                    {
                        return BadRequest("Order must be confirmed before shipping");
                    }
                    break;
                case OrderStatus.Delivered :
                    if(order.Status == OrderStatus.Shipped)
                    {
                         order.Status = orderstatus;
                    }
                    else
                    {
                        return BadRequest("Order must be shipped before delivery");
                    }
                    break;
                case OrderStatus.Cancelled :
                    if(order.Status == OrderStatus.Pending ||order.Status == OrderStatus.OrderConfirm)
                    {
                         order.Status = orderstatus;
                    }
                    else
                    {
                        return BadRequest($"Order cannot be cancelled at {order.Status}");
                    }
                    break;

                default: return BadRequest("Status not supported for update");
            }

            unitOfWork.Repository<Order>().Update(order);
            if (orderstatus == OrderStatus.Cancelled)
                {
                    // Add the product to stock back within the same transaction
                    await ReturnProductsToStock(order);
                    // Refund case if online paymen :

                }
            if(await unitOfWork.Complete())
            {
                return Ok($"Order has been {order.Status}");
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
