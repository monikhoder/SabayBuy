using AutoMapper;
using API.Dtos;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api")]
[ApiController]
public class ProductVariantsController(
    IUnitOfWork unit,
    IMapper mapper) : ControllerBase
{
    // GET: api/products/{productId}/variants
    [HttpGet("products/{productId}/variants")]
    public async Task<ActionResult<IReadOnlyList<ProductVariantDto>>> GetVariants(Guid productId)
    {
        var spec = new ProductVariantSpecification(productId);
        var variants = await unit.Repository<ProductVariant>().ListAsync(spec);
        return Ok(mapper.Map<IReadOnlyList<ProductVariant>, IReadOnlyList<ProductVariantDto>>(variants));
    }


    // POST: api/products/{productId}/variants
    [HttpPost("products/{productId}/variants")]
    public async Task<ActionResult<ProductVariantDto>> CreateVariant(Guid productId, CreateProductVariantDto variantDto)
    {

        var product = await unit.Repository<Product>().GetByIdAsync(productId);
        if (product == null) return NotFound("Product not found");

        var variant = mapper.Map<CreateProductVariantDto, ProductVariant>(variantDto);
        variant.ProductId = productId;

        unit.Repository<ProductVariant>().Add(variant);

        if (await unit.Complete())
        {
            var returnDto = mapper.Map<ProductVariant, ProductVariantDto>(variant);
            return CreatedAtAction(nameof(GetVariant), new { id = variant.Id }, returnDto);
        }

        return BadRequest("Failed to add variant");
    }

    // GET: api/variants/{id}
    [HttpGet("variants/{id}")]
    public async Task<ActionResult<ProductVariantDto>> GetVariant(Guid id)
    {
        var spec = new ProductVariantSpecification(id, true);
        var variant = await unit.Repository<ProductVariant>().GetEntityWithSpec(spec);

        if (variant == null) return NotFound();

        return Ok(mapper.Map<ProductVariant, ProductVariantDto>(variant));
    }


    // PUT: api/variants/{id}
    [HttpPut("variants/{id}")]
    public async Task<ActionResult> UpdateVariant(Guid id, UpdateProductVariantDto variantDto)
    {
        var spec = new ProductVariantSpecification(id, true);
        var variant = await unit.Repository<ProductVariant>().GetEntityWithSpec(spec);

        if (variant == null) return NotFound();
        mapper.Map(variantDto, variant);
        unit.Repository<ProductVariant>().Update(variant);

        if (await unit.Complete())
        {
             return Ok(mapper.Map<ProductVariant, ProductVariantDto>(variant));
        }

        return BadRequest("Failed to update variant");
    }


    // DELETE: api/variants/{id}
    [HttpDelete("variants/{id}")]
    public async Task<ActionResult> DeleteVariant(Guid id)
    {
        var variant = await unit.Repository<ProductVariant>().GetByIdAsync(id);
        if (variant == null) return NotFound();

        unit.Repository<ProductVariant>().Delete(variant);

        if (await unit.Complete()) return Ok("Variant deleted successfully");

        return BadRequest("Failed to delete variant");
    }
}