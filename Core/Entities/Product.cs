using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Product : BaseEntity
{
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? BaseImageUrl { get; set; }
    public string Brand { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }

    // Navigation Properties
    public virtual Category? Category { get; set; }

    public virtual ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();

}
