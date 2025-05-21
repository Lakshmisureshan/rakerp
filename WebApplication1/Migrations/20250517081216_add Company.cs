using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "467d2381-b853-422b-b9cd-302886aa6809", "AQAAAAEAACcQAAAAEFRWzsOqrF465GMUQt40UcSlkFJmOwzOr3yfv9K4r/gFJheCjlTpl1VoTeMyG3OO0w==", "cfa6cd86-a6e3-49b0-b055-da9b9039570e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0885aeb6-75b2-46e8-ba8c-5c76388841cc", "AQAAAAEAACcQAAAAEEdrQNACl8TdMirWM1QExocQ64NM3olLkXk2fQLtwzaiQjRQKHqzFxzd06nmCFNePw==", "2576b20f-d7f7-4384-8456-ae5727ad5177" });
        }
    }
}
