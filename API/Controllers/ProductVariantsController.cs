using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api")]
[ApiController]
public class ProductVariantsController(
    IGenericRepository<ProductVariant> variantRepo,
    IGenericRepository<Product> productRepo,
    IMapper mapper) : ControllerBase
{
    // GET: api/products/{productId}/variants
    [HttpGet("products/{productId}/variants")]
    public async Task<ActionResult<IReadOnlyList<ProductVariantDto>>> GetVariants(Guid productId)
    {
        var spec = new ProductVariantSpecification(productId);
        var variants = await variantRepo.ListAsync(spec);
        return Ok(mapper.Map<IReadOnlyList<ProductVariant>, IReadOnlyList<ProductVariantDto>>(variants));
    }


    // POST: api/products/{productId}/variants
    [HttpPost("products/{productId}/variants")]
    public async Task<ActionResult<ProductVariantDto>> CreateVariant(Guid productId, CreateProductVariantDto variantDto)
    {

        var product = await productRepo.GetByIdAsync(productId);
        if (product == null) return NotFound("Product not found");

        var variant = mapper.Map<CreateProductVariantDto, ProductVariant>(variantDto);
        variant.ProductId = productId;

        variantRepo.Add(variant);

        if (await variantRepo.SaveAllAsync())
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
        var variant = await variantRepo.GetEntityWithSpec(spec);

        if (variant == null) return NotFound();

        return Ok(mapper.Map<ProductVariant, ProductVariantDto>(variant));
    }


    // PUT: api/variants/{id}
    [HttpPut("variants/{id}")]
    public async Task<ActionResult> UpdateVariant(Guid id, UpdateProductVariantDto variantDto)
    {
        var spec = new ProductVariantSpecification(id, true);
        var variant = await variantRepo.GetEntityWithSpec(spec);

        if (variant == null) return NotFound();
        mapper.Map(variantDto, variant);
        variantRepo.Update(variant);

        if (await variantRepo.SaveAllAsync())
        {
             return Ok(mapper.Map<ProductVariant, ProductVariantDto>(variant));
        }

        return BadRequest("Failed to update variant");
    }


    // DELETE: api/variants/{id}
    [HttpDelete("variants/{id}")]
    public async Task<ActionResult> DeleteVariant(Guid id)
    {
        var variant = await variantRepo.GetByIdAsync(id);
        if (variant == null) return NotFound();

        variantRepo.Delete(variant);

        if (await variantRepo.SaveAllAsync()) return Ok("Variant deleted successfully");

        return BadRequest("Failed to delete variant");
    }
}