using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public List<CategoryDto> SubCategories { get; set; } = new();
}
public class CreateCategoryDto
{
    [Required(ErrorMessage = "Category name Cannot be empty")]
    public string CategoryName { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public Guid? ParentCategoryId { get; set; }
}
public class UpdateCategoryDto
{
    public string CategoryName { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public Guid? ParentCategoryId { get; set; }
}