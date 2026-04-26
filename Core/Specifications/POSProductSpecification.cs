using Core.Entities;

namespace Core.Specifications;

public class POSProductSpecification : BaseSpecification<ProductVariant>
{
    public POSProductSpecification(POSProductSpecParams specParams)
        : base(x =>
            x.IsActive &&
            x.Product != null &&
            x.Product.IsActive &&
            (string.IsNullOrEmpty(specParams.Search) ||
                x.Product.ProductName.ToLower().Contains(specParams.Search.ToLower()) ||
                x.Sku.ToLower().Contains(specParams.Search.ToLower())) &&
            (specParams.Categories.Count == 0 ||
                (x.Product.Category != null && specParams.Categories.Contains(x.Product.Category.CategoryName))) &&
            (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Product.Brand)) &&
            (!specParams.InStockOnly || x.StockQuantity > 0)
        )
    {
        AddInclude(x => x.Product!);
        AddInclude("Product.Category");
        AddInclude(x => x.Attributes);
        ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

        switch (specParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(x => x.Price);
                break;
            case "stockAsc":
                AddOrderBy(x => x.StockQuantity);
                break;
            case "stockDesc":
                AddOrderByDescending(x => x.StockQuantity);
                break;
            case "nameAsc":
                AddOrderBy(x => x.Product!.ProductName);
                break;
            case "nameDesc":
                AddOrderByDescending(x => x.Product!.ProductName);
                break;
            default:
                AddOrderBy(x => x.Product!.ProductName);
                break;
        }
    }
}
