using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class TestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6cd890b8-6a23-448f-a177-2f8df2338573", "AQAAAAEAACcQAAAAELUaHAzeqpkiSTQjO7ybdxtRJPebVWJUkwoijkY+RNodxDwjeq7v4VkXJ3qUo1BmXw==", "84a66c1a-1e4c-4254-91bf-5ec850c84b71" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51071b64-a3e2-4a06-8c5a-a4879ef916af", "AQAAAAEAACcQAAAAEJK1LBF6OH1NRwAAP4yciJIPPpgnFxKsHbAQl8ua8x8Ep5lIMvF03PryGAv8n38Dgg==", "a5b41faf-a75d-437e-a0e9-f1eed3fcdff9" });
        }
    }
}
