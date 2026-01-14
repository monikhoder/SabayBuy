using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.CategoryName).IsRequired().HasMaxLength(100);
        builder.HasIndex(x => x.CategoryName).IsUnique();
        builder.Property(x => x.Icon).HasMaxLength(100);
        builder.HasOne(x => x.ParentCategory)
               .WithMany(x => x.SubCategories)
               .HasForeignKey(x => x.ParentCategoryId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(x => x.SubCategories)
               .WithOne(x => x.ParentCategory)
               .HasForeignKey(x => x.ParentCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

    }
}
