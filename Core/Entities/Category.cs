using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Category : BaseEntity
{
    public string CategoryName { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public Guid? ParentCategoryId { get; set; }

    // Navigation Properties
    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

}
