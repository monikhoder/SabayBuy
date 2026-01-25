using System;

using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;


public class CreateProductDto
{
    [Required] public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? BaseImageUrl { get; set; }
    [Required] public string Brand { get; set; } = string.Empty;
    [Required] public Guid CategoryId { get; set; }

    public List<CreateProductVariantDto> Variants { get; set; } = new();
}

public class CreateProductVariantDto
{
    [Required] public string Sku { get; set; } = string.Empty;
    [Required] public decimal Price { get; set; }
    [Required] public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public List<CreateVariantAttributeDto> Attributes { get; set; } = new();
}

public class CreateVariantAttributeDto
{
    [Required] public string AttributeName { get; set; } = string.Empty;
    [Required] public string AttributeValue { get; set; } = string.Empty;
}


