using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addproductcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productcode",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6831f4ad-f46b-4209-bab6-408781360c42", "AQAAAAEAACcQAAAAECaq2ECCGVOVbAu1RP6/KZ64XO3+OH2YZp0SNZP/v+OocyxZ76wP9Foxkl38bygZHg==", "05d84d0f-911e-4184-8690-4a86cfeba038" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productcode",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f42279bd-4e8c-4f07-9cf8-dc6161837752", "AQAAAAEAACcQAAAAEJ8DLj8DoaxZSu9P3kK6cPCM1NwjxpQcwhn+ZvNJhq7h93pR5t/GphIMaYlpxTaVfg==", "18c415a5-5744-49b0-9bbd-753d9748069b" });
        }
    }
}
