using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addbomstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bomstatus",
                table: "Bom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e69530ab-af98-4987-8184-08bef8609f90", "AQAAAAEAACcQAAAAECbuylbQjqXxoic2QJHg/YAPUwRyHN7cRzVb/yEeFNXSI92hRNGCZ6BeU4zPyaI6fw==", "884a352f-cd9f-417a-b6b5-38362d512915" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bomstatus",
                table: "Bom");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8149c54-4e7c-4c03-ac95-df35bc23f066", "AQAAAAEAACcQAAAAEM4/tug8gS/1PMtTF0EJ5vqK0Ew2zRE481WfwUmYN3at+3rp1U3HgWY5wJ0IjxVQPw==", "4551dbed-f5a7-494d-aff7-6cf9a8d86d8a" });
        }
    }
}
