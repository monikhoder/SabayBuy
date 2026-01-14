using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class VariantAttributeConfiguration : IEntityTypeConfiguration<VariantAttribute>
{
    public void Configure(EntityTypeBuilder<VariantAttribute> builder)
    {
        builder.Property(x => x.VariantId).IsRequired();
        builder.Property(x => x.AttributeName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.AttributeValue).IsRequired().HasMaxLength(50);
        builder.HasOne(x => x.Variant)
               .WithMany(x => x.Attributes)
               .HasForeignKey(x => x.VariantId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
