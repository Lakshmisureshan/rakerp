using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class fhfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64758da0-b684-4b0c-8df6-ebbe8bd01bba", "AQAAAAEAACcQAAAAECjw+AYkn8Yy19PhY41hSPhS227PKAY+q5K4XonisK+ZJ32qQZx4y/iDhRlaDWulaQ==", "93056b76-6e69-406c-8ec3-b8425b78e8e3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d0a8b3f-f1a1-4461-8102-00b01a3d16a7", "AQAAAAEAACcQAAAAEMpvQ7R01Gy5vKLY2exvWnlYoLhQJSWI7sveSfaBb5QwIJDhZwsbgAcqV2stsv8uSA==", "cd74a4be-378a-4a93-8e3e-34a81f227142" });
        }
    }
}
