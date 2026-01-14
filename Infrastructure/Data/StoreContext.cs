using System;
using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StoreContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductVariant> ProductVariants { get; set; }
    public DbSet<VariantAttribute> VariantAttributes { get; set;}
    public DbSet<Category> Categories { get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductVariantConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VariantAttributeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
    }
}
