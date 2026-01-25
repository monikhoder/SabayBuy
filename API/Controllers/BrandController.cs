using AutoMapper;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController(
        IGenericRepository<Product> repo
    ) : ControllerBase
    {
        // GET: api/brand
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            var spec = new BrandListSpecification();
            var brands = await repo.ListAsync(spec);
            return Ok(brands);
        }
    }
}
