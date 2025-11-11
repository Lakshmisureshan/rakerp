using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addggg0008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fec841f0-783d-4a03-9dd4-ef3a89b2cc40", "AQAAAAEAACcQAAAAEHesbb7p5l0TKgBy9+YbhWKR1rafI3na+NXuhq9fAN5AksVmzYkbrz3R6vSGlPcNrQ==", "cb87fba7-9010-4ca1-990b-800cab948a98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2df008a5-9700-40ef-845f-da6ebc72f22f", "AQAAAAEAACcQAAAAEJCRyLiGtgDKuLksAysxM6qs9V86WRCucpjkrTlcw9aD8Cwrrj8E5QL5CwDHRmCBzw==", "71beadc9-8c95-46b0-8209-51f47eba2a0d" });
        }
    }
}
