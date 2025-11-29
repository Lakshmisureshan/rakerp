using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addgggsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "270b6fa3-e5d7-41f6-9118-47c2a7a45935", "AQAAAAEAACcQAAAAEC4AdTRmiPhK5QMAjB+rABYdBKWLzn7GDjDPmBTDOn97M9LJKwXK8jIOfN1TNUbmzQ==", "a7b30767-1af3-4845-9a13-54f6694661ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fc0ea5c-c982-454d-888f-46ff92a4a00d", "AQAAAAEAACcQAAAAEM41bNN1vyBHHl6OTKwEdCUHquDH6OMUIxP8qG9Y/HVAO0n+61rJ3DkOiIuai7ZBxg==", "73e7dc82-ecd5-4116-80a3-e58a1864ce37" });
        }
    }
}
