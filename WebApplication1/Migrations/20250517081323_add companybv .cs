using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcompanybv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    companyid = table.Column<int>(type: "int", nullable: false),
                    companyname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.companyid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01265240-9698-45d9-acfa-330eff6744d9", "AQAAAAEAACcQAAAAEJsVkZZd4qYHQRAfO2XrMQ2GyRXq+j5a28xAjs3L5ytC52LTu3mcPPXtgQ5w5Ym5+g==", "32493e25-55b4-4f11-9085-2d076cc3c4e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "467d2381-b853-422b-b9cd-302886aa6809", "AQAAAAEAACcQAAAAEFRWzsOqrF465GMUQt40UcSlkFJmOwzOr3yfv9K4r/gFJheCjlTpl1VoTeMyG3OO0w==", "cfa6cd86-a6e3-49b0-b055-da9b9039570e" });
        }
    }
}
