using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(x => x.ShippingAddress, o => o.WithOwner());
            builder.Property(x => x.PaymentMethod).HasConversion(
                    o => o.ToString(),
                    s => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), s)
                );
            builder.Property(x => x.Status).HasConversion(
                o => o.ToString(),
                s => (OrderStatus)Enum.Parse(typeof(OrderStatus), s)
            );
            builder.Property(x => x.Subtotal).HasColumnType("decimal(18,2)");
            builder.HasMany(x => x.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.OrderDate).HasConversion(
                d => d.ToUniversalTime(),
                d => DateTime.SpecifyKind(d, DateTimeKind.Utc)
            );
        }
    }
}
