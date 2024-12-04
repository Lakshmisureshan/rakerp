using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addsartingseries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "startingseries",
                table: "JobType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9986e2b2-7fad-4574-8c19-cf617c0babe3", "AQAAAAEAACcQAAAAEFbbkJ0cqWq8TJ2nG4kr6Hjr11ZJ5OFooPcmvougzaRd7Vx2pbqnvSjS+ylZnehEaA==", "9cfbe7d4-79a1-46ba-bf63-86d220d706a4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "startingseries",
                table: "JobType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a30d8a1a-9387-4b1b-a2ab-a5de081830cf", "AQAAAAEAACcQAAAAENbxX4k/b27cjI1ii6yvBNkwi3J4+XPjUHgCkv/zdHwQcv09paY4aZmW5k3tYkiuEg==", "6b0f5530-2f68-477c-b94d-8b43eb31d68e" });
        }
    }
}
