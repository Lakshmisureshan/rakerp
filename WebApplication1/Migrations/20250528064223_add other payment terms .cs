using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addotherpaymentterms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "otherpaymentremarks",
                table: "PO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e32cb79-86d3-4072-acde-c7dc55d30def", "AQAAAAEAACcQAAAAEPwJ0W3UkY4K1Rp7vkVHJ5ANfJ9po2VB8TV8Bs0bmCcxZwvl4NqKv2NohLE3Lq6orA==", "0e0aaab4-de01-445c-9193-2da206212eb2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "otherpaymentremarks",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a10fc98f-44e4-4808-90d4-00f1078eff74", "AQAAAAEAACcQAAAAEBM9BlvnFbdxAFUwWw2Cdyqb+nvfcoTnhQHsliOJZ7dieMcqoGkF2gf9gXM7tZLFTA==", "2c81544c-7d75-4507-863b-e039b99e5187" });
        }
    }
}
