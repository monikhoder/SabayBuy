using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ProductVariant : BaseEntity
{
    public Guid ProductId { get; set; }
    public string Sku { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    // Navigation Properties
    public virtual Product? Product { get; set; }

    public virtual ICollection<VariantAttribute> Attributes { get; set; } = new List<VariantAttribute>();
}
