using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addisregisteredinreceivedentry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isregistered",
                table: "ReceivedEntry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbaf534f-dc40-4c8f-9960-8713d20b9b17", "AQAAAAEAACcQAAAAEAqLuw1ZvbS+njZzT/9rKxI6F2JKvc4BNXKZZomtNXcbEExsAe16N8NPKGX7w376oA==", "e2b8efbc-3b48-4af8-9b69-a14f2956cb46" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isregistered",
                table: "ReceivedEntry");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc376a36-3747-40bb-9f63-e5dc3a1e1e9d", "AQAAAAEAACcQAAAAEP+AgXsF2M+oPM7O78wZwWJmmpubd+ekOiG9DECWWJl8u/Dytr7Skl692Lhm0NsiUA==", "b47113f7-4481-435f-b163-c15b401b91ae" });
        }
    }
}
