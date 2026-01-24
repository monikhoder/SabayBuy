using System;
using Core.Entities;

namespace Core.Specifications;

public class CategoriesSpecification : BaseSpecification<Category>
{
    public CategoriesSpecification(string? sort, bool? isParent, string? search = null) : base(
        c =>
            (string.IsNullOrEmpty(search) || c.CategoryName.ToLower().Contains(search.ToLower())) &&
            (!isParent.HasValue || (isParent.Value ? c.ParentCategoryId == null : c.ParentCategoryId != null))
    )
    {
        AddInclude(c => c.SubCategories);
        AddInclude(c => c.ParentCategory!);
        switch (sort)
        {
            case "nameDesc":
                AddOrderByDescending(c => c.CategoryName);
                break;
            default:
                AddOrderBy(c => c.CategoryName);
                break;
        }
    }
    public CategoriesSpecification(Guid id) : base(c => c.Id == id)
    {
        AddInclude(c => c.SubCategories);
        AddInclude(c => c.ParentCategory!);
    }
}