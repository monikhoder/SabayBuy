using Core.Entities;

namespace Core.Specifications;

public class ProductsSpecification : BaseSpecification<Product>
{
    // សម្រាប់ Get All (មាន Search, Filter, Sort)
    public ProductsSpecification(ProductSpecParams specParams)
        : base(x =>
            (string.IsNullOrEmpty(specParams.Search) || x.ProductName.ToLower().Contains(specParams.Search.ToLower())) &&
            (specParams.Categories.Count == 0 || specParams.Categories.Contains(x.Category!.CategoryName)) &&
            (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand))
        )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize
        );
        AddInclude(x => x.Category!);
        AddInclude(x => x.Variants);
        AddInclude("Variants.Attributes"); // Using string include for nested navigation property

        switch (specParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(p => p.Variants.Min(v => v.Price));
                break;
            case "priceDesc":
                AddOrderByDescending(p => p.Variants.Min(v => v.Price));
                break;
            case "dateAsc":
                AddOrderBy(p => p.CreatedAt);
                break;
            case "dateDesc":
                AddOrderByDescending(p => p.CreatedAt);
                break;
            case "nameAsc":
                AddOrderBy(p => p.ProductName);
                break;
            case "nameDesc":
                AddOrderByDescending(p => p.ProductName);
                break;
            default:
                AddOrderByDescending(p => p.CreatedAt);
                break;
        }
    }

    // Get By ID
    public ProductsSpecification(Guid id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Category!);
        AddInclude(x => x.Variants);
        AddInclude("Variants.Attributes");
    }
}