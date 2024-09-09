using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13721584-8cc3-4f65-9282-97bf59794582", "AQAAAAEAACcQAAAAEDNqc/QMgEJGc0TZdOIXsWyXHWKrGVW58vB+vdXzK+XW7reWcAwvFsoUxOX/60GcaA==", "6fb5801b-d177-41c1-b343-d1f31ab858be" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1be071a-8219-4ba6-8ba9-ce3b71b16eee", "AQAAAAEAACcQAAAAELYxRwHQ0bH2+wykstG02pG+hOMFmlMsIAKBY7xEE1CmWQbaBp8wI2GqPVLpl3i6Ow==", "bde058bf-9ac5-4ce4-84eb-dd5a7053f42f" });
        }
    }
}
