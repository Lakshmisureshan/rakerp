using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06bbb1f0-c47f-4708-a4f4-68511f12bad5", "AQAAAAEAACcQAAAAEHb+/9IQFk+KiI4dG7INGj0Aqz1iiyLyQ3t/VniYnfkljGqrMvWDOIutm2ow3s8nqQ==", "7aa335dc-9572-436f-93a1-9f8b62f860ad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a178a06c-c678-49dd-be15-750e0a14457a", "AQAAAAEAACcQAAAAEKaWEDMKHGyMl4RLi23rKpxDtwND0P/rQrJ4F0m78FoboXp5U12oyJ1bIZAnMU588g==", "ff69f529-68e5-4322-8c4d-eb6caf20ba0f" });
        }
    }
}
