using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.BaseImageUrl).HasMaxLength(500);
        builder.Property(x => x.CategoryId).IsRequired();
        builder.Property(x => x.Brand).IsRequired().HasMaxLength(100);
        builder.HasOne(x => x.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.Variants)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}
