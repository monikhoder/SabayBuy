using Core.Entities;

namespace Core.Specifications;

public class ProductsSpecification : BaseSpecification<Product>
{
    // សម្រាប់ Get All (មាន Search, Filter, Sort)
    public ProductsSpecification(string? sort, Guid? categoryId, string? brand, string? search)
        : base(x =>
            (string.IsNullOrEmpty(search) || x.ProductName.ToLower().Contains(search.ToLower())) &&
            (!categoryId.HasValue || x.CategoryId == categoryId) &&
            (string.IsNullOrEmpty(brand) || x.Brand.ToLower() == brand.ToLower())
        )
    {
        AddInclude(x => x.Category!);
        AddInclude(x => x.Variants);
        AddInclude("Variants.Attributes"); // Using string include for nested navigation property

        switch (sort)
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