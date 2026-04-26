using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize(Roles = "Admin,Seller")]
public class POSProductController(IUnitOfWork unitOfWork, IMapper mapper) : BaseApiController
{
    // GET: api/posproduct
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<POSProductVariantDto>>> GetProducts(
        [FromQuery] POSProductSpecParams specParams)
    {
        var spec = new POSProductSpecification(specParams);
        return await CreatePageResult<ProductVariant, POSProductVariantDto>(
            unitOfWork.Repository<ProductVariant>(),
            spec,
            specParams.PageIndex,
            specParams.PageSize,
            mapper);
    }
}
