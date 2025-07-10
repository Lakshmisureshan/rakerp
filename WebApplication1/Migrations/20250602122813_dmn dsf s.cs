using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dmndsfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a86ab625-fe6c-4cd5-a7e7-eabe37ef7111", "AQAAAAEAACcQAAAAED5so1cIvcuBNTUe2KCuTBhc8BCQPUaJD6gAZ4aptaL+L8znhQNuxA1W/VlQq1TMgA==", "664c86a7-d8ff-45a0-ba4e-ff280624b939" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "601903a1-32f2-4f6e-9540-2bcf327e5cea", "AQAAAAEAACcQAAAAEAzMThGHn4/G9kKBJpSyhZxk7HLcOd2pdLoRsDYW8DXsokn29n7lxg9BKhBF0C1fhg==", "fe67ad39-5aee-46b2-9059-3dc10c94f5a7" });
        }
    }
}
