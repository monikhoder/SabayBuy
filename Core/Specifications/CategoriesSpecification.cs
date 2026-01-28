using System;
using Core.Entities;

namespace Core.Specifications;

public class CategoriesSpecification : BaseSpecification<Category>
{
    public CategoriesSpecification(CategorySpecParams specParams) : base(
        c =>
            (string.IsNullOrEmpty(specParams.Search) || c.CategoryName.ToLower().Contains(specParams.Search.ToLower())) &&
            (!specParams.isParent.HasValue || (specParams.isParent.Value ? c.ParentCategoryId == null : c.ParentCategoryId != null))
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
        AddInclude(c => c.SubCategories);
        AddInclude(c => c.ParentCategory!);
        switch (specParams.Sort)
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