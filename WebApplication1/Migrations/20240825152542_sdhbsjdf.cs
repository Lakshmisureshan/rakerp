using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class sdhbsjdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productname",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1abced28-85d9-41d1-bf4a-21d931cd8d68", "AQAAAAEAACcQAAAAEAq4bXhLQm6zlZGi7ejdxjla7SPKh9NvpYE4F8nXAbf1c4GDs+a62inMw6iVUkN4qA==", "276a6339-e2ba-4796-af41-8f8be4ef6109" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "productname",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5e6b0d6-d915-45e4-a272-8f354926e202", "AQAAAAEAACcQAAAAEFuIzncf3VG5PLQy9FVWgE5jMkEM5I1awDGlT+SfgpArwF0FL/X/oVyNvvuzoX8vMw==", "917d6da9-a214-4d7c-910f-d796abc341be" });
        }
    }
}
