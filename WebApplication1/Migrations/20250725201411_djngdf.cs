using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class djngdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "counter",
                table: "Miscost",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c84beb3e-1821-4e01-a919-b4e80300f22b", "AQAAAAEAACcQAAAAEJoa4k76DJUuEdJsXQWgXBN8lId3hqymGfcG+q0jFt22z+80gEtIZQR8EVotgDtITg==", "8da4358a-7755-49ea-9ea5-622f8ef406a7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "counter",
                table: "Miscost");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "900a7da8-7acf-49c3-a39b-0833b8a22832", "AQAAAAEAACcQAAAAEDTgYvCA5tgh2ypdPhNhX14AsUZwEb+VYFePdoKSfA3s5cBkXoj972M++rAvvi1jyA==", "c688c4c4-fefd-4c05-9b45-4a89ef47ec13" });
        }
    }
}
