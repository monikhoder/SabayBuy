using API.Helpers;
using AutoMapper;
using API.Dtos;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class ProductsController(IUnitOfWork unit, IMapper mapper) : BaseApiController
    {
        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(
            [FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductsSpecification(specParams);
            return await CreatePageResult<Product, ProductDto>(unit.Repository<Product>(), spec, specParams.PageIndex, specParams.PageSize, mapper);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            var spec = new ProductsSpecification(id);
            return await GetByIdResult<Product, ProductDto>(unit.Repository<Product>(), spec, mapper);
        }

        // POST: api/products
        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductDto productDto)
        {
            var product = mapper.Map<CreateProductDto, Product>(productDto);
            unit.Repository<Product>().Add(product);
            if (await unit.Complete())
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
            var product = await unit.Repository<Product>().GetByIdAsync(id);
            if (product == null) return NotFound();
            mapper.Map(productDto, product);
            unit.Repository<Product>().Update(product);
            if (await unit.Complete()) return Ok(mapper.Map<Product, ProductDto>(product));
            return BadRequest("Failed to update product");
        }
        [Authorize(Roles = "Admin,Stock")]
        //Put : api/products/status/{id}
        [HttpPut("status/{id}")]
        public async Task<ActionResult> UpdateProductStatus(Guid id)
        {
            var product = await unit.Repository<Product>().GetByIdAsync(id);
            if (product == null) return NotFound();
            if (product.IsActive) product.IsActive = false; else product.IsActive = true;
             unit.Repository<Product>().Update(product);
            if (await unit.Complete()) return Ok("Product status updated");
            return BadRequest("Failed to update product");
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await unit.Repository<Product>().GetByIdAsync(id);
            if (product == null) return NotFound();
            unit.Repository<Product>().Delete(product);
            if (await unit.Complete()) return Ok("Product deleted successfully");
            return BadRequest("Failed to delete product");
        }
    }
}
