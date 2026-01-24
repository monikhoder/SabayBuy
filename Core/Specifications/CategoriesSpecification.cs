using System;
using Core.Entities;

namespace Core.Specifications;

public class CategoriesSpecification : BaseSpecification<Category>
{
    public CategoriesSpecification(string? sort, bool? isParent)
    {
        AddInclude(c => c.SubCategories);
        AddInclude(c => c.ParentCategory!);
        if (isParent.HasValue)
        {
            if (isParent.Value)
            {
                AddCriteria(c => c.ParentCategoryId == null);
            }
            else
            {
                AddCriteria(c => c.ParentCategoryId != null);
            }
        }
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
    public CategoriesSpecification(string? search)
    {
        AddInclude(c => c.SubCategories);
        AddInclude(c => c.ParentCategory!);
        if (!string.IsNullOrEmpty(search))
        {
            AddCriteria(c => c.CategoryName.ToLower().Contains(search.ToLower()));
        }
    }
}