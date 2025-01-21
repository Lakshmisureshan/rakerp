using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcolumninissuetracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "issuecurrencyid",
                table: "Issuetracking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "issueunitprice",
                table: "Issuetracking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "issueuomid",
                table: "Issuetracking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d85ebc9-68e3-4ad9-96de-4a8f6eb39fe5", "AQAAAAEAACcQAAAAEF+kLF+mg+yM3tztsIq2zO160sxQVu8Ijh1ZvQxTQIaXbfNn3a6oOOlZevCmeIujrQ==", "e22abb9b-0ece-4fc9-ba39-2c3cac3ee008" });

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_issuecurrencyid",
                table: "Issuetracking",
                column: "issuecurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_issueuomid",
                table: "Issuetracking",
                column: "issueuomid");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuetracking_Currency_issuecurrencyid",
                table: "Issuetracking",
                column: "issuecurrencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuetracking_UOM_issueuomid",
                table: "Issuetracking",
                column: "issueuomid",
                principalTable: "UOM",
                principalColumn: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issuetracking_Currency_issuecurrencyid",
                table: "Issuetracking");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuetracking_UOM_issueuomid",
                table: "Issuetracking");

            migrationBuilder.DropIndex(
                name: "IX_Issuetracking_issuecurrencyid",
                table: "Issuetracking");

            migrationBuilder.DropIndex(
                name: "IX_Issuetracking_issueuomid",
                table: "Issuetracking");

            migrationBuilder.DropColumn(
                name: "issuecurrencyid",
                table: "Issuetracking");

            migrationBuilder.DropColumn(
                name: "issueunitprice",
                table: "Issuetracking");

            migrationBuilder.DropColumn(
                name: "issueuomid",
                table: "Issuetracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef6f45d-93a4-4d38-9ffa-cf7a8d3ed0ed", "AQAAAAEAACcQAAAAEMqc2Bs5osOnf+yyQdx02PIXZ2ig3uHqe5dd2oEfdXvJrFbwQc0j2Entxl2kfzia+w==", "3404051c-4bcd-4d6a-b387-8152a1a71f8e" });
        }
    }
}
