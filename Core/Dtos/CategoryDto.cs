using System;

namespace Core.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public List<CategoryDto> SubCategories { get; set; } = new();
}
public class CreateCategoryDto
{
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