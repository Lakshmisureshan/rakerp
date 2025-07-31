using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addinvid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "invid",
                table: "InventoryHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e1cedf8-a0be-4888-95a2-05772d7b4116", "AQAAAAEAACcQAAAAEO71CODd8iViqsKg6cqFJgZSrhylzRhBq6Xx0BEZv6AKqDPUkBrGc/4/EN9H+CdJfw==", "0a7c5e5b-bce2-4c5b-958e-7fc8b09a9719" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "invid",
                table: "InventoryHistory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c64184a6-a148-4206-8e3c-a2c9effa9085", "AQAAAAEAACcQAAAAECiM9ikycMl90Lbr7CfaQQcmBkR/xnoIKyYhXjd0wqurBs3Be0l6EaWK0V517J8Mbg==", "c146c0c7-0483-49f2-aabc-c0bb26515680" });
        }
    }
}
