

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

        [HttpGet("with-products")]
        public async Task<ActionResult<IReadOnlyList<CategoryDto>>> GetCategoriesWithProducts()
        {
            var spec = new CategoriesWithProductsSpecification();
            var categories = await unit.Repository<Category>().ListAsync(spec);
            var mappedCategories = mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoryDto>>(categories);
            var categoriesWithProducts = mappedCategories
                .Where(category => category.ProductCount > 0)
                .ToList();

            return Ok(categoriesWithProducts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid id)
        {
            var spec = new CategoriesSpecification(id);
            return await GetByIdResult<Category, CategoryDto>(unit.Repository<Category>(), spec, mapper);
        }


        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CreateCategoryDto categoryDto)
        {
            var spec = new CategoryByNameSpecification(categoryDto.CategoryName);
            var existingCategory = await unit.Repository<Category>().GetEntityWithSpec(spec);

            if (existingCategory != null)
            {
                return BadRequest("Category with this name already exists");
            }

            var newCategory = mapper.Map<CreateCategoryDto, Category>(categoryDto);
            unit.Repository<Category>().Add(newCategory);
            if (await unit.Complete())
            {
                var categoryToReturn = mapper.Map<Category, CategoryDto>(newCategory);
                return CreatedAtAction(nameof(GetCategory), new { id = categoryToReturn.Id }, categoryToReturn);
            }
            return BadRequest("Failed to create category");
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(Guid id, UpdateCategoryDto categoryDto)
        {
            var spec = new CategoriesSpecification(id);
            var existingCategory = await unit.Repository<Category>().GetEntityWithSpec(spec);
            if (existingCategory == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(categoryDto.CategoryName) && existingCategory.CategoryName != categoryDto.CategoryName)
            {
                var nameSpec = new CategoryByNameSpecification(categoryDto.CategoryName);
                var categoryWithName = await unit.Repository<Category>().GetEntityWithSpec(nameSpec);

                if (categoryWithName != null)
                {
                    return BadRequest("Category with this name already exists");
                }
            }

            mapper.Map(categoryDto, existingCategory);
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
            var specParams = new ProductSpecParams();
            specParams.Categories.Add(category.CategoryName);
            var productspec = new ProductsSpecification(specParams);
            var product = await unit.Repository<Product>().GetEntityWithSpec(productspec);

            if (product != null)
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
