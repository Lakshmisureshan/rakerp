using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addjobrefinbom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82692a6a-4e9a-47a3-8d77-864fb3da8eaf", "AQAAAAEAACcQAAAAEGmohBqkmwy3ETrBPYbJMkYRwbjGRJCNwy2JKwUl0qTnWcuThu0RYziZTpoIHHf8xQ==", "760f511b-1ef7-4f96-b61a-b63d55f476b8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b75decaa-662c-446f-881e-e17e8ae74bac", "AQAAAAEAACcQAAAAEKhn+/rHUL0BcAVpbkBebK1LhVt3ygYW5XkGgkJcoERR2+rneo4/pfYyANLIfHH1nw==", "36a1daee-aa68-4a64-8032-6d94728ba790" });
        }
    }
}
