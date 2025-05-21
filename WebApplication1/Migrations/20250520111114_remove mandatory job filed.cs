using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class removemandatoryjobfiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd7073ee-b203-41c7-a171-689d0fe89f89", "AQAAAAEAACcQAAAAEF1EdowsdrCjPR9VmcaPnVI4dMuRx8aBgg6lhID71rA1eTyVBPp1yWlZGJHOwLSjpg==", "e275bd33-d9ae-4308-983d-2af857427898" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5c5fb92-1a58-4efd-9664-ce3fa05ee9b3", "AQAAAAEAACcQAAAAEA05lGvQV4umm8oKK2F7zG0V2bZenPk+gpfLHtCVZr4cJRuMpGlD8Qm2esrFoUkn3Q==", "8714d9fa-cf42-461b-9edc-ac17ab237d07" });
        }
    }
}
