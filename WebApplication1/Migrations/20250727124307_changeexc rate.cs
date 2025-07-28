using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class changeexcrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "poexchangerate",
                table: "PO",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83fb056c-c9de-451a-8b3f-b5a00d1e4be5", "AQAAAAEAACcQAAAAEJ30nA3LhNos3JKOWyNHAlrOoROcgnnqj4w1YM6NABWqFc9nWETjzi+Ix7gyqWccVA==", "455d7175-41d4-462d-9985-0e3b3a2b8ba1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "poexchangerate",
                table: "PO",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a73823d2-c342-4956-b3f0-ef7f19947668", "AQAAAAEAACcQAAAAEBtEuhvJYOje1qpYma/GlczfBHemfRQ700qIJv8YnTqi7prQ5rT/yiwJlgZ1oQEyKQ==", "0adde0e4-3679-437d-a22d-f20c964ad066" });
        }
    }
}
