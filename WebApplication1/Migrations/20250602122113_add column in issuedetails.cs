using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcolumninissuedetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "601903a1-32f2-4f6e-9540-2bcf327e5cea", "AQAAAAEAACcQAAAAEAzMThGHn4/G9kKBJpSyhZxk7HLcOd2pdLoRsDYW8DXsokn29n7lxg9BKhBF0C1fhg==", "fe67ad39-5aee-46b2-9059-3dc10c94f5a7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c4833e8-4fba-48d7-8d2b-f2335c1a8976", "AQAAAAEAACcQAAAAEBIAte7eCzEe/P9/w+tjEZCR3DoGzcBBM/v/MPQHQuoTZ/3Vi2mrgTk3/unAIvSCng==", "f1e0ef8b-39ee-4f55-82a9-7ac95e96db2c" });
        }
    }
}
