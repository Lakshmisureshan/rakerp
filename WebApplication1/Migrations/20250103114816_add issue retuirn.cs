using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissueretuirn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a8aa62c-40c8-40fb-b100-2a4a938d7077", "AQAAAAEAACcQAAAAEO5F8aHMjfsmTjZda25S708Rlpm8/NrlWg5Zx6e3+HgID9nRaFZB6MNxseksiT9eLA==", "d549177d-ea81-4a6f-90b0-b64176341bb0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31323a27-8c49-4bec-8060-26c945d5ce3a", "AQAAAAEAACcQAAAAEA7/SP/NR0aPeuFqiVhorVoCIBvfOxjwJOSBwBR+dndyJKy4RJR6pDJY9h0cDNLY+Q==", "98e305d0-61b4-4e4a-8139-01251765f759" });
        }
    }
}
