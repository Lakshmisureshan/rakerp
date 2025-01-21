using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddfsdbf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "issuerefno",
                table: "Inventoryreservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30626941-c9a4-4fc7-80a1-b9f8343d6df0", "AQAAAAEAACcQAAAAEBcdEoJb7WS/j77lQ+RzeCReq0YVHKaS3nu8t0+O91ns5ISgyWC/0j0dIBP4QWA9rg==", "0779cc05-231b-4881-8b7d-684b0e28f3fe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "issuerefno",
                table: "Inventoryreservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee8f3ae5-3656-465c-bd75-0569ba0b8057", "AQAAAAEAACcQAAAAEGf1uF+jYSyQtJ+Goa56+68R6C8vJ4JWNTepyUm3Cky+1bLgDXqg+OoNImA91UjBMw==", "def0fa0d-4956-4bb8-97c4-3a10b2b61648" });
        }
    }
}
