

using AutoMapper;
using API.Dtos;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class CategoriesController(IUnitOfWork unit, IMapper mapper) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetCategories([FromQuery] CategorySpecParams specParams)
        {
            var spec = new CategoriesSpecification(specParams);
            return await CreatePageResult<Category, CategoryDto>(unit.Repository<Category>(), spec, specParams.PageIndex, specParams.PageSize, mapper);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
        {
            var spec = new CategoriesSpecification(id);
            return await GetByIdResult<Category, CategoryDto>(unit.Repository<Category>(), spec, mapper);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto category)
        {

            return await CreateResult<Category, CreateCategoryDto, CategoryDto>(
                unit.Repository<Category>(),
                category,
                mapper,
                nameof(GetCategory),
                entity => new { id = entity.Id });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(Guid id, UpdateCategoryDto category)
        {
           var spec = new CategoriesSpecification(id);
           var existingCategory = await unit.Repository<Category>().GetEntityWithSpec(spec);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                mapper.Map(category, existingCategory);
                unit.Repository<Category>().Update(existingCategory);

                if (await unit.Complete())
                {
                    return mapper.Map<Category, CategoryDto>(existingCategory);
                }

                return BadRequest("Failed to update category");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            // Check if category exists
            var spec = new CategoriesSpecification(id);
            var category = await unit.Repository<Category>().GetEntityWithSpec(spec);
            if (category == null) return NotFound();
            if(category.SubCategories != null && category.SubCategories.Any())
            {
                return BadRequest("Cannot delete category with subcategories");
            }
            if(category.Products != null && category.Products.Any())
            {
                return BadRequest("Cannot delete category with products");
            }
            unit.Repository<Category>().Delete(category);

            if (await unit.Complete())
            {
                return Ok("category deleted successfully");
            }
            return BadRequest("Failed to delete category");
        }
    }
}
