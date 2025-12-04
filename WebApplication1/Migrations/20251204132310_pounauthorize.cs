using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class pounauthorize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64f47090-7c66-44db-aacd-1dbaa5bf20b0", "AQAAAAEAACcQAAAAECac8JHx/zokIU3gAg5Ko5puMwQ5230FLFjSG9SbDopLI89HRQyjWqGjsh1Y6uM3hA==", "5c3c72cb-9fed-4930-94e9-0ef81dbc7fb1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25039f36-4288-4288-9dd3-6e4c856fcc63", "AQAAAAEAACcQAAAAEK/vXRCE/aM2r5AlBSW4zZR8jwz8E3Yv9jyXTxDzS1UuIhaLlRyoDgmegImcq5tTiQ==", "f3c3fa43-c8a0-4f40-937e-b5240b911bcd" });
        }
    }
}
