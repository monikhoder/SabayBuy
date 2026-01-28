

using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class CategoriesController(IGenericRepository<Category> repository, IMapper mapper) : BaseApiController
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetCategories([FromQuery] CategorySpecParams specParams)
        {
            var spec = new CategoriesSpecification(specParams);
            return await CreatePageResult<Category, CategoryDto>(repository, spec, specParams.PageIndex, specParams.PageSize, mapper);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
        {
            var spec = new CategoriesSpecification(id);
            return await GetByIdResult<Category, CategoryDto>(repository, spec, mapper);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto category)
        {

            return await CreateResult<Category, CreateCategoryDto, CategoryDto>(
                repository,
                category,
                mapper,
                nameof(GetCategory),
                entity => new { id = entity.Id });
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(Guid id, UpdateCategoryDto category)
        {
           var spec = new CategoriesSpecification(id);
           var existingCategory = await repository.GetEntityWithSpec(spec);
                if (existingCategory == null)
                {
                    return NotFound();
                }
                mapper.Map(category, existingCategory);
                repository.Update(existingCategory);

                if (await repository.SaveAllAsync())
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
            var category = await repository.GetEntityWithSpec(spec);
            if (category == null) return NotFound();
            if(category.SubCategories != null && category.SubCategories.Any())
            {
                return BadRequest("Cannot delete category with subcategories");
            }
            if(category.Products != null && category.Products.Any())
            {
                return BadRequest("Cannot delete category with products");
            }
            repository.Delete(category);

            if (await repository.SaveAllAsync())
            {
                return Ok("category deleted successfully");
            }
            return BadRequest("Failed to delete category");
        }
    }
}
