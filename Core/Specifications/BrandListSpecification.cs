using System;
using Core.Entities;

namespace Core.Specifications;

public class BrandListSpecification : BaseSpecification<Product, string>
{
    public BrandListSpecification(string? sort, string? search)
        : base(x => string.IsNullOrEmpty(search) || x.Brand.ToLower().Contains(search.ToLower()))
    {
        AddSelector(p => p.Brand);
        ApplyDistinct();
        switch (sort)
        {
            case "nameDesc":
                AddOrderByDescending(p => p.Brand);
                break;
            default:
                AddOrderBy(p => p.Brand);
                break;
        }
    }
}
