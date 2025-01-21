using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adsnbdfsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "838c5cef-cfd3-4f3a-80ac-cde3c8d2d8b6", "AQAAAAEAACcQAAAAEPDme6kF7ZmnUfSZN+9Aesti6daYvVNQI8Dxyfu7+e4fouzl3832ArYwxqILZjcQgg==", "369caa59-a2b7-4d53-aa18-7c8e3368f828" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67388e99-b18f-4df5-bf51-46f1a9501c85", "AQAAAAEAACcQAAAAEPFF6cvK+OYzkeir9pvYtgFpf/mGYktjQiLDFqUT7LLXy8/rfohgVgrTuwKWy2WhuA==", "0db786b7-4218-4990-a534-fc34c2c03a46" });
        }
    }
}
