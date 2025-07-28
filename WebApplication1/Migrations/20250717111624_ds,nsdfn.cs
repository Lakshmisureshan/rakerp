using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dsnsdfn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "location",
                table: "grntracking",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58890f63-8353-4490-9590-56584d9045e1", "AQAAAAEAACcQAAAAEHfesB5yQdtTXMJ3NZ1vsAtZ2+SiMfRIBS18mh04ABH2PxvqA5sM8/G2wRq7XoM1gQ==", "a18d29c5-9c1c-48e9-9a29-9ecda70b0e5d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "location",
                table: "grntracking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a07ed28e-5fc2-4097-82bb-2bce8f51803a", "AQAAAAEAACcQAAAAEA3mKTOG79V+y+2TULc8zKHFqwjEHNDpGXcEBBklQwd2jg7Tw6p2MAkdgI87VkTSnQ==", "768f2dc7-6f5e-41a9-9206-a3d030f29256" });
        }
    }
}
