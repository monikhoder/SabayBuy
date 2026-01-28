using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BrandController(
        IGenericRepository<Product> repo
    ) : BaseApiController
    {
        // GET: api/brand
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands(string? sort, string? search)
        {
            var spec = new BrandListSpecification(sort, search);
            var brands = await repo.ListAsync(spec);
            return Ok(brands);
        }
    }
}
