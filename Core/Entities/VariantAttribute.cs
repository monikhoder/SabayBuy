using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class VariantAttribute : BaseEntity
{
    public Guid VariantId { get; set; }
    public string AttributeName { get; set; } = string.Empty;
    public string AttributeValue { get; set; } = string.Empty;
    // Navigation Properties
    public virtual ProductVariant? Variant { get; set; }
}
