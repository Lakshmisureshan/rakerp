using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addpostatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51af3ade-a151-480c-8781-09c2dfc9280d", "AQAAAAEAACcQAAAAEMOmY+Cnjw/DfXPHT0HmCvNQVOYbTT5oQl2FbGFy+GCM+hGrtAjCy093KAPZ5eE83A==", "de93d356-98e0-462e-883d-537d612d4a71" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e6581f6-df92-4014-bc9d-ee9f96f380e7", "AQAAAAEAACcQAAAAEHwJl/tiZw+49ipYiOxuN5znClT1aZGG7lT50wzN8qgWRzp71Aiysf6Nnbw/1So8gw==", "787d1ed2-a03b-47aa-b6db-a6f3974fd5ac" });
        }
    }
}
