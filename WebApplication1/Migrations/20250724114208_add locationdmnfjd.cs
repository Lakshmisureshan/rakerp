using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addlocationdmnfjd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "900a7da8-7acf-49c3-a39b-0833b8a22832", "AQAAAAEAACcQAAAAEDTgYvCA5tgh2ypdPhNhX14AsUZwEb+VYFePdoKSfA3s5cBkXoj972M++rAvvi1jyA==", "c688c4c4-fefd-4c05-9b45-4a89ef47ec13" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec7bb1f2-8659-4399-a07f-24b9f91d9ad9", "AQAAAAEAACcQAAAAEMPiIpIhyZT8iCXFt0ZDSc/PQ2AxD6ikI3VnsKrFngXLAzr6ouwpjmbHjRj6fXarhw==", "621df45b-e928-48e4-b85e-dd7446336719" });
        }
    }
}
