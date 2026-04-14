using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "a21bfa3e-8b00-48a0-8e28-4d47f2161ea4",
                    ConcurrencyStamp = "a21bfa3e-8b00-48a0-8e28-4d47f2161ea4", // <--- បន្ថែមបន្ទាត់នេះ
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "4419bcaa-4f04-4b51-ab61-0c2e1381a249",
                    ConcurrencyStamp = "4419bcaa-4f04-4b51-ab61-0c2e1381a249", // <--- បន្ថែមបន្ទាត់នេះ
                    Name = "Stock",
                    NormalizedName = "STOCK"
                },
                new IdentityRole
                {
                    Id = "2615fbdd-bd23-4b35-be6f-975fc6e9de87",
                    ConcurrencyStamp = "2615fbdd-bd23-4b35-be6f-975fc6e9de87", // <--- បន្ថែមបន្ទាត់នេះ
                    Name = "Seller",
                    NormalizedName = "SELLER"
                },
                new IdentityRole
                {
                    Id = "378f1430-fed7-4425-8bac-65486c7d65d6",
                    ConcurrencyStamp = "378f1430-fed7-4425-8bac-65486c7d65d6", // <--- បន្ថែមបន្ទាត់នេះ
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
            );
        }
    }
}
