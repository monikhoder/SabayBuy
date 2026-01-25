using System;
using Core.Entities;

namespace Core.Specifications;

public class ProductVariantSpecification : BaseSpecification<ProductVariant>
{
    public ProductVariantSpecification(Guid productId)
        : base(x => x.ProductId == productId)
    {
        AddInclude(x => x.Attributes);
        AddOrderBy(x => x.Price);
    }
    public ProductVariantSpecification(Guid id, bool isDetail)
        : base(x => x.Id == id)
    {
        AddInclude(x => x.Attributes);
    }

}
