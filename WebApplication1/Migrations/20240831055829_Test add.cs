using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Testadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "jobid",
                table: "Bom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b75decaa-662c-446f-881e-e17e8ae74bac", "AQAAAAEAACcQAAAAEKhn+/rHUL0BcAVpbkBebK1LhVt3ygYW5XkGgkJcoERR2+rneo4/pfYyANLIfHH1nw==", "36a1daee-aa68-4a64-8032-6d94728ba790" });

            migrationBuilder.CreateIndex(
                name: "IX_Bom_jobid",
                table: "Bom",
                column: "jobid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bom_Job_jobid",
                table: "Bom",
                column: "jobid",
                principalTable: "Job",
                principalColumn: "Jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bom_Job_jobid",
                table: "Bom");

            migrationBuilder.DropIndex(
                name: "IX_Bom_jobid",
                table: "Bom");

            migrationBuilder.DropColumn(
                name: "jobid",
                table: "Bom");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc735770-8690-4b17-b055-327ad14b32e3", "AQAAAAEAACcQAAAAEKlJNhRatei9+wTgrrRgEq15aJaTWVtszm3wpMS6P/CADajD16+Y1sP9bifCyUftIg==", "ced3df64-c6f1-4661-add3-f6cf9f9fae79" });
        }
    }
}
