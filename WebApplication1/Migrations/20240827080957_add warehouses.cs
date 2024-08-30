using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addwarehouses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8ee986c-4d84-4f4c-803c-557bd4c98cd8", "AQAAAAEAACcQAAAAEOT12UdWVY/KYwQUYoeCvdnjrWt2c7yDkVGOJ2L845BOc8DuSK95bSEn2G8EfmdNlg==", "81e34395-7627-4cc2-9de8-ff6762ca7052" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1abced28-85d9-41d1-bf4a-21d931cd8d68", "AQAAAAEAACcQAAAAEAq4bXhLQm6zlZGi7ejdxjla7SPKh9NvpYE4F8nXAbf1c4GDs+a62inMw6iVUkN4qA==", "276a6339-e2ba-4796-af41-8f8be4ef6109" });
        }
    }
}
