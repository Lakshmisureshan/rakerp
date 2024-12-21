using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addunitpriceandcurrencyininventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e479d82-734a-4c7b-a06b-5093edf7203c", "AQAAAAEAACcQAAAAEAKIUOI6US8LpvWwQTTwE3sqQY+xFyvbNQdxiE7go8VMv09ejJZnflDYu2DVBosi0w==", "f3f9f6ee-4f34-45aa-9f8b-effa74ae092b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0217f9ec-9af7-493c-a9ea-cee0f4e8ff55", "AQAAAAEAACcQAAAAEIhlpoynmbMU9kRTnTI7B4qvcENufUMFX/vuRh5VcNzA+N1mPDsh/BK5xImwDGgeZg==", "631c32f2-e00f-448a-b5ed-13ac30b4e5b7" });
        }
    }
}
