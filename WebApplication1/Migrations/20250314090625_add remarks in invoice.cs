using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addremarksininvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "remarks",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff5c2385-172f-4926-b367-d3e53c1b4fda", "AQAAAAEAACcQAAAAEKngXAk4YAf0JUCYgQWrnxVuxCnvgh9gR95X3t8htnZQrtFUNV3gtYT7/di7RNUQ5A==", "9b888930-8614-4ac7-af05-593e13bbc1ce" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "remarks",
                table: "Invoice");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9c17bc7-4d19-4ceb-b3cf-9579e2049770", "AQAAAAEAACcQAAAAEAtZG+gBQMjuCQa9B05qbKbfuW8oD4o6blwkdWEPl0bKhidr4v6RhN/cSxLeYjAs6A==", "5475214b-877a-4a06-b1b5-011b26f16f32" });
        }
    }
}
