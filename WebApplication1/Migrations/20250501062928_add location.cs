using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addlocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "394de643-26d3-4b30-b4b4-422fe22ed87d", "AQAAAAEAACcQAAAAEBXSFhCqKcmFUHz3gBDp892et+4bObXuq6hhyt8fgcAINleaJA3Jvg/jEUDegl255Q==", "e5b81ac4-6050-4a07-8363-1d9db4f28293" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location",
                table: "Inventory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c4b1a4f-596b-4ebb-84a8-4352bd95b415", "AQAAAAEAACcQAAAAEKfuEI9eGYuD5dur4gbtnqKj7FyK0irCe62SAjB0kBQ0PMXV2N7XOGtk4j0D78YKMQ==", "f719d79d-ca57-468d-b4f2-239312b889cb" });
        }
    }
}
