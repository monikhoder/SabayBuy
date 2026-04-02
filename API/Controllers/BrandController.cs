using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BrandController(
        IUnitOfWork unit
    ) : BaseApiController
    {
        // GET: api/brand
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands(string? sort, string? search)
        {
            var spec = new BrandListSpecification(sort, search);
            var brands = await unit.Repository<Product>().ListAsync(spec);
            return Ok(brands);
        }
    }
}
