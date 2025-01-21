using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addreservagtiontime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "reservationtime",
                table: "Inventoryreservation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbe68ce0-f814-4c4f-ada0-066ea1e4cb73", "AQAAAAEAACcQAAAAEGz1wvUZGN17pEb6oVUG4CM6ZJmzsfpyEnmEDMzDCGMr92aaWzhzOQCA+nrz6hUdwg==", "aab313f9-4a17-4653-aff8-3721af7f14e7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservationtime",
                table: "Inventoryreservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c86c0196-fd5a-4cbd-b318-7c14058b3efb", "AQAAAAEAACcQAAAAECjLp1+8F1dHchJOjnpeh2jGn09PjiVGudJmhuhi7x1WRvBvEpr8qywdH0D0TJeYIQ==", "390dfb76-b71f-421f-899a-e70bbd7b7915" });
        }
    }
}
