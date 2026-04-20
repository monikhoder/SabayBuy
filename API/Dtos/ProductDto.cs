using System;

namespace API.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? BaseImageUrl { get; set; }
    public bool IsActive { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int? Stock { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<ProductVariantDto> Variants { get; set; } = new();
}


