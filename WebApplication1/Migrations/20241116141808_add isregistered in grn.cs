using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addisregisteredingrn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isregistered",
                table: "GRNHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b343929-d2a1-4fd1-95b3-17fc0a7b1f6e", "AQAAAAEAACcQAAAAEETR2c807/OFKTdeofZbuPjPanYXzAcNv6zp8VByQB347cJ83hTO77sPxdjYR6RgaQ==", "3db062a6-97bf-4d0a-bd26-32d53c16c505" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isregistered",
                table: "GRNHeader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a0d2bca-8ee0-4af4-867b-57aada77ad41", "AQAAAAEAACcQAAAAEBvUxDP2I43LZ5U9Mi3w+A/IRqV1Bl1u0gkkwJF84bevaJ7ASG3KVO3nMTOGIUNRgQ==", "af271ac8-0182-4d87-a641-4d28a312c4a9" });
        }
    }
}
