using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addprcreatedqty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "prcreatedqty",
                table: "Bom",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f2eaa13-9f0d-4ee6-9a02-89ba3c19a265", "AQAAAAEAACcQAAAAEJ00bl3++9Z7XH6vIOa2A94/aRe9zbKVQJ3ft8KBMP2ra+paXWHgP7eNjtqjjyodPw==", "354504d4-0524-4774-b8ba-57fc88903431" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prcreatedqty",
                table: "Bom");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e69530ab-af98-4987-8184-08bef8609f90", "AQAAAAEAACcQAAAAECbuylbQjqXxoic2QJHg/YAPUwRyHN7cRzVb/yEeFNXSI92hRNGCZ6BeU4zPyaI6fw==", "884a352f-cd9f-417a-b6b5-38362d512915" });
        }
    }
}
