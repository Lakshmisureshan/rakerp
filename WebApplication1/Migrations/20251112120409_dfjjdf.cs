using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dfjjdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "776acd22-f0ef-49bf-a125-94cc03c067a5", "AQAAAAEAACcQAAAAEFmm7jXtjASqBpBr6vp7VEULmGoIOEH15VMlw0K0Pqb7SAdtS/GEe4e8dPSWk99pXQ==", "98589c87-c115-4937-893c-44fa0e6516e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "270b6fa3-e5d7-41f6-9118-47c2a7a45935", "AQAAAAEAACcQAAAAEC4AdTRmiPhK5QMAjB+rABYdBKWLzn7GDjDPmBTDOn97M9LJKwXK8jIOfN1TNUbmzQ==", "a7b30767-1af3-4845-9a13-54f6694661ae" });
        }
    }
}
