using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class sdbjbsdfsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "grntracking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a07ed28e-5fc2-4097-82bb-2bce8f51803a", "AQAAAAEAACcQAAAAEA3mKTOG79V+y+2TULc8zKHFqwjEHNDpGXcEBBklQwd2jg7Tw6p2MAkdgI87VkTSnQ==", "768f2dc7-6f5e-41a9-9206-a3d030f29256" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location",
                table: "grntracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8ddd665-611f-4dbc-8bf6-cdb876f511b6", "AQAAAAEAACcQAAAAEBxPf+JySv2TCrwxPnAdijEnVt/Bv0apZzROtUDVAzgZBL3v1dj0nINhn8nGfQXsIQ==", "6dc4166d-db2a-4733-a9f9-19740f55ce12" });
        }
    }
}
