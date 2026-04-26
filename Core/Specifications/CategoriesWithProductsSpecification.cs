using Core.Entities;

namespace Core.Specifications;

public class CategoriesWithProductsSpecification : BaseSpecification<Category>
{
    public CategoriesWithProductsSpecification() : base(category =>
        category.Products.Any() ||
        category.SubCategories.Any(subCategory => subCategory.Products.Any()))
    {
        AddInclude(category => category.SubCategories);
        AddInclude(category => category.ParentCategory!);
        AddInclude(category => category.Products);
        AddInclude("SubCategories.Products");
        AddOrderBy(category => category.CategoryName);
    }
}
