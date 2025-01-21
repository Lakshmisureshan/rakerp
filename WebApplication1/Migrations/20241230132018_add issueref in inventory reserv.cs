using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuerefininventoryreserv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "issuerefno",
                table: "Inventoryreservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff82b233-913e-4445-9ab0-97625b066858", "AQAAAAEAACcQAAAAENpSqQZ66qq9f6qQq1bEE08JoHDjrfkHFHd6bKtZvedBxH9WT0cjj/ZB/S6hAIIGLg==", "3ce5648d-eb89-48c1-963a-56ce0ce4503a" });
        }
    }
}
