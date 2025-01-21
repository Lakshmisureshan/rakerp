using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addtypeininventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c4aa404-822c-4070-aa05-8e89c4a8693a", "AQAAAAEAACcQAAAAEBJPlRLd8FSMVSFPGqgTODRCEJ8Wm0jWMMqd/godaBOeRCvoGNd4Dyuw+AV0nUTBdQ==", "690a34b8-45d7-47a7-85dc-026c7766e6fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "Inventory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b773b166-2027-4223-bd79-3961ad305601", "AQAAAAEAACcQAAAAEJpOHPi41w8E0ohLAJEnUswoFZrXRypk9ZDRFgzPUs2ixBVDn0J01W8ExCKDKzZasA==", "da0495d3-4cb6-42aa-aef8-ffcc990dec7a" });
        }
    }
}
