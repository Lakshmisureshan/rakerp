using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29651a0f-1320-4053-a33b-28cd8c56b315", "AQAAAAEAACcQAAAAENA1Vv0ROXGv5A1g61CoD8K5IOwR35IlS7aulC12H81G0nFOJJfwT2vCR8mRHcZ/JA==", "492eed7b-62d8-4fdc-9906-4f8955c52a60" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bdf15a1-6234-4e48-843b-14bde44f3dd9", "AQAAAAEAACcQAAAAEFgSb6XlU6Dh/4P+dkNYqWFtBWrJWRsmqxaz/UzWvLy+qcbBoa7rrRZE7gWgHsD2IQ==", "cd56c855-35dc-44d3-8a7a-8b4f80c99008" });
        }
    }
}
