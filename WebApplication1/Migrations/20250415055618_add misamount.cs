using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmisamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "misamount",
                table: "Miscost",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6725110f-4b2b-4b95-8f80-73c81b6682c1", "AQAAAAEAACcQAAAAED88vTMLP03RHnLkGmrnUTUkuBUAo6zT2WJ5tncOY0AaOQTr3tJCqvRT7A4nEsJT+g==", "614ce615-822f-4380-ae2f-fa3feae5433a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "misamount",
                table: "Miscost");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10606da4-fbb7-4c83-ba8a-5dad88974f02", "AQAAAAEAACcQAAAAEIqTz5Su9qb4ABIC7qiZ4c+QGbdde7dGMhQ9tEpghD1pibHBnYKVPmWoqBnPLHlMNw==", "559d5050-6aad-41d9-ae83-108b2de8c138" });
        }
    }
}
