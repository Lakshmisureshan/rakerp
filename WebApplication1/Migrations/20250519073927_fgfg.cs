using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class fgfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21ec6bc5-25cf-49f3-bc5a-6d7bfb419fad", "AQAAAAEAACcQAAAAEAkfjMyakWn8HTiVIiWpmhjcMXRJsEySikx7an6UDrOCYm0ZmW9Q7kgp4iTsLL1fGw==", "9340996e-4594-4de9-bf4e-1b1d593849d5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29651a0f-1320-4053-a33b-28cd8c56b315", "AQAAAAEAACcQAAAAENA1Vv0ROXGv5A1g61CoD8K5IOwR35IlS7aulC12H81G0nFOJJfwT2vCR8mRHcZ/JA==", "492eed7b-62d8-4fdc-9906-4f8955c52a60" });
        }
    }
}
