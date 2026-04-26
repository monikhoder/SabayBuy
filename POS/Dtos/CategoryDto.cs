using System;
using System.Collections.Generic;

namespace POS.Dtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public string Icon { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public int ProductCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<CategoryDto> SubCategories { get; set; }
    }
}
