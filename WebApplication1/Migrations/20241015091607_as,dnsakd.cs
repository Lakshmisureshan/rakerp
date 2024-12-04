using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class asdnsakd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "315a23e8-d0f7-4fc9-92fe-ac5ee5572e17", "AQAAAAEAACcQAAAAEAW7Eo6J1rKPK+3el90z3p+YvyYERze0mBwHCIEqbBUGfQ3v7Ja+aJt+sZta09wxKg==", "57bc0405-092c-47a4-b5c4-d7c1700bf629" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15d93113-575e-4c02-95df-725f7b56897c", "AQAAAAEAACcQAAAAEElPfZ4YY5NO6E4LAt1TPL+LhnvrA7NCe9Q4MzP8VI1lzoKqDsbFRSSKNg5vbmX7QA==", "37bcf466-be80-477d-9aec-b380401209f1" });
        }
    }
}
