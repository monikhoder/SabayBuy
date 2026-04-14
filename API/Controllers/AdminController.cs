using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interface;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(IUnitOfWork unitOfWork, IMapper mapper) : BaseApiController
    {
        [HttpGet("orders")]
        public async Task<ActionResult<IReadOnlyList<OrderDto>>> GetOrders(
            [FromQuery] OrderSpecParams specParams)
        {
            var spec = new OrderSpecification(specParams);
            return await CreatePageResult<Order, OrderDto>(unitOfWork.Repository<Order>(), spec, specParams.PageIndex, specParams.PageSize, mapper);
        }

    }
}
