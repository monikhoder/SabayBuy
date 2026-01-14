using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Config;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductVariant> builder)
    {
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.Sku).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        builder.Property(x => x.StockQuantity).IsRequired();
        builder.Property(x => x.ImageUrl).HasMaxLength(500);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
        builder.HasOne(x => x.Product)
               .WithMany(x => x.Variants)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x => x.Attributes)
                .WithOne(x => x.Variant)
                .HasForeignKey(x => x.VariantId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
