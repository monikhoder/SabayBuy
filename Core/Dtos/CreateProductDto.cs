using System;

using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;


public class CreateProductDto
{
    [Required(ErrorMessage = "Product name cannot be empty")] public string ProductName { get; set; } = string.Empty;
    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")] public string? Description { get; set; }
    public string? BaseImageUrl { get; set; }
    [Required(ErrorMessage = "Brand cannot be empty")]
    [StringLength(15, ErrorMessage = "Brand cannot exceed 15 characters")]
     public string Brand { get; set; } = string.Empty;
    [Required(ErrorMessage = "Category cannot be empty")] public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "Product variants cannot be empty")] public List<CreateProductVariantDto> Variants { get; set; } = new();
}

public class CreateProductVariantDto
{
    [Required (ErrorMessage = "SKU is required")]
    [StringLength(50, ErrorMessage = "SKU cannot exceed 50 characters")]
    [RegularExpression(@"^\S+$", ErrorMessage = "SKU cannot contain spaces")]
     public string Sku { get; set; } = string.Empty;
    [Required (ErrorMessage = "Price cannot be empty")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
     public decimal Price { get; set; }
    [Required (ErrorMessage = "Stock quantity cannot be empty")]
    [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a non-negative integer")]
     public int StockQuantity { get; set; }
    public string? ImageUrl { get; set; }
    public List<CreateVariantAttributeDto> Attributes { get; set; } = new();
}

public class CreateVariantAttributeDto
{
    [Required(ErrorMessage = "Attribute name is required")]
    [StringLength(15, ErrorMessage = "Attribute name cannot exceed 15 characters")]
     public string AttributeName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Attribute value is required")]
    [StringLength(15, ErrorMessage = "Attribute value cannot exceed 15 characters")]
     public string AttributeValue { get; set; } = string.Empty;
}


