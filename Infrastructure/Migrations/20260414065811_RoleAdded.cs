using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2615fbdd-bd23-4b35-be6f-975fc6e9de87", "2615fbdd-bd23-4b35-be6f-975fc6e9de87", "Seller", "SELLER" },
                    { "378f1430-fed7-4425-8bac-65486c7d65d6", "378f1430-fed7-4425-8bac-65486c7d65d6", "Customer", "CUSTOMER" },
                    { "4419bcaa-4f04-4b51-ab61-0c2e1381a249", "4419bcaa-4f04-4b51-ab61-0c2e1381a249", "Stock", "STOCK" },
                    { "a21bfa3e-8b00-48a0-8e28-4d47f2161ea4", "a21bfa3e-8b00-48a0-8e28-4d47f2161ea4", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2615fbdd-bd23-4b35-be6f-975fc6e9de87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "378f1430-fed7-4425-8bac-65486c7d65d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4419bcaa-4f04-4b51-ab61-0c2e1381a249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a21bfa3e-8b00-48a0-8e28-4d47f2161ea4");
        }
    }
}
