using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class fd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e8f5a73-f374-4400-a3fe-5e937b6e5bde", "AQAAAAEAACcQAAAAEPeKrKsNAmaK2Im4WStM7h0uUUqeuz/nv/66Gat0YLeceCbn2gAah8HNSPz5kU0I3w==", "46600571-2d0e-44e8-ad0b-2ab0d7747152" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64758da0-b684-4b0c-8df6-ebbe8bd01bba", "AQAAAAEAACcQAAAAECjw+AYkn8Yy19PhY41hSPhS227PKAY+q5K4XonisK+ZJ32qQZx4y/iDhRlaDWulaQ==", "93056b76-6e69-406c-8ec3-b8425b78e8e3" });
        }
    }
}
