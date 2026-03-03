using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.FirstName)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.LastName)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.HasMany(u => u.Addresses)
                   .WithOne(a => a.User)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
