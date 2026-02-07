using API.Helpers;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController(IGenericRepository<Product> repo, IMapper mapper) : BaseApiController
    {
        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(
            [FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductsSpecification(specParams);
            return await CreatePageResult<Product, ProductDto>(repo, spec, specParams.PageIndex, specParams.PageSize, mapper);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            var spec = new ProductsSpecification(id);
            return await GetByIdResult<Product, ProductDto>(repo, spec, mapper);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto productDto)
        {
            var product = mapper.Map<CreateProductDto, Product>(productDto);
            repo.Add(product);
            if (await repo.SaveAllAsync())
            {
                var returnDto = mapper.Map<Product, ProductDto>(product);
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, returnDto);
            }

            return BadRequest("Failed to create product");
        }

        //Put : api/products/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, UpdateProductDto productDto)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            mapper.Map(productDto, product);
            repo.Update(product);
            if (await repo.SaveAllAsync()) return Ok(mapper.Map<Product, ProductDto>(product));
            return BadRequest("Failed to update product");
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            repo.Delete(product);
            if (await repo.SaveAllAsync()) return Ok("Product deleted successfully");
            return BadRequest("Failed to delete product");
        }
    }
}
