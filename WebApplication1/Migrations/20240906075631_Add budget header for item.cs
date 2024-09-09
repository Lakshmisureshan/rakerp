using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addbudgetheaderforitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51071b64-a3e2-4a06-8c5a-a4879ef916af", "AQAAAAEAACcQAAAAEJK1LBF6OH1NRwAAP4yciJIPPpgnFxKsHbAQl8ua8x8Ep5lIMvF03PryGAv8n38Dgg==", "a5b41faf-a75d-437e-a0e9-f1eed3fcdff9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13721584-8cc3-4f65-9282-97bf59794582", "AQAAAAEAACcQAAAAEDNqc/QMgEJGc0TZdOIXsWyXHWKrGVW58vB+vdXzK+XW7reWcAwvFsoUxOX/60GcaA==", "6fb5801b-d177-41c1-b343-d1f31ab858be" });
        }
    }
}
