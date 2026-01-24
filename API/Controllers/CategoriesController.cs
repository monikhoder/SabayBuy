
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(IGenericRepository<Category> repository, IMapper mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetCategories(string? sort, bool? isParent)
        {
          var spec = new CategoriesSpecification(sort, isParent);
          var categories = await repository.ListAsync(spec);
          return Ok(mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryDto>>(categories));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
        {
            var spec = new CategoriesSpecification(id);
            var category = await repository.GetEntityWithSpec(spec);
            if(category == null) return NotFound();
            return mapper.Map<Category, CategoryDto>(category);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto category)
        {
            //check if name exists
            if (await CategoryNameExists(category.CategoryName))
            {
                return BadRequest("Category name already exists");
            }
            var newCategory = mapper.Map<CreateCategoryDto, Category>(category);
            repository.Add(newCategory);
            if (await repository.SaveAllAsync())
            {
                return CreatedAtAction(nameof(GetCategory), new { id = newCategory.Id }, newCategory);
            }
            return BadRequest("Failed to create category");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CreateCategoryDto>> UpdateCategory(Guid id, UpdateCategoryDto category)
        {
           var spec = new CategoriesSpecification(id);
           var existingCategory = await repository.GetEntityWithSpec(spec);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                if (await CategoryNameExists(category.CategoryName))
                {
                    return BadRequest("Category name already exists");
                }

                mapper.Map(category, existingCategory);
                repository.Update(existingCategory);

                if (await repository.SaveAllAsync())
                {
                    return Ok(existingCategory);
                }

                return BadRequest("Failed to update category");
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var spec = new CategoriesSpecification(id);
            var category = await repository.GetEntityWithSpec(spec);
            if (category == null)
            {
                return NotFound();
            }

            repository.Delete(category);

            if (await repository.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Failed to delete category");
        }
        private async Task<bool> CategoryNameExists(string categoryName)
        {
            var spec = new CategoriesSpecification(null);
            var categories = await repository.ListAsync(spec);
            return categories.Any(c => c.CategoryName.ToLower() == categoryName.ToLower());
        }
    }
}
