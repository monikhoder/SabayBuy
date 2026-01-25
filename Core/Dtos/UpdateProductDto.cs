using System;

namespace Core.Dtos;

public class UpdateProductDto
{
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? BaseImageUrl { get; set; }
    public string? Brand { get; set; }
    public Guid? CategoryId { get; set; }
}
public class UpdateProductVariantDto
{
    public string Sku { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public List<CreateVariantAttributeDto> Attributes { get; set; } = new();
}
