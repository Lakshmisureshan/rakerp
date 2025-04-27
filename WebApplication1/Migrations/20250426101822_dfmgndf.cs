using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dfmgndf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf8d914e-bab5-4e09-8c57-790b68518335", "AQAAAAEAACcQAAAAEO8Kpz1D6wIXYQ3rliMT8TmTF4kOovElSL36XaLCx/N2puRZyJ/qXrNeZU6gAAk1Mw==", "75f46ceb-b29e-480b-909e-da6d1c993481" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9a10877-a96b-4417-aa83-874c4846fcaf", "AQAAAAEAACcQAAAAEIU3+f+wNveRY2NEZ8MXsrVHXuVUPIhcjv1ZggZval4KlJcJtQ4Fy5lTaB1avlv6Zg==", "16f1c99c-b9a2-43c8-827c-2012794aeaf6" });
        }
    }
}
