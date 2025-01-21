using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addremainingingrntracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "grncurrencyid",
                table: "grntracking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "grnunitprice",
                table: "grntracking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "grnuomid",
                table: "grntracking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ef6f45d-93a4-4d38-9ffa-cf7a8d3ed0ed", "AQAAAAEAACcQAAAAEMqc2Bs5osOnf+yyQdx02PIXZ2ig3uHqe5dd2oEfdXvJrFbwQc0j2Entxl2kfzia+w==", "3404051c-4bcd-4d6a-b387-8152a1a71f8e" });

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_grncurrencyid",
                table: "grntracking",
                column: "grncurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_grnuomid",
                table: "grntracking",
                column: "grnuomid");

            migrationBuilder.AddForeignKey(
                name: "FK_grntracking_Currency_grncurrencyid",
                table: "grntracking",
                column: "grncurrencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_grntracking_UOM_grnuomid",
                table: "grntracking",
                column: "grnuomid",
                principalTable: "UOM",
                principalColumn: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grntracking_Currency_grncurrencyid",
                table: "grntracking");

            migrationBuilder.DropForeignKey(
                name: "FK_grntracking_UOM_grnuomid",
                table: "grntracking");

            migrationBuilder.DropIndex(
                name: "IX_grntracking_grncurrencyid",
                table: "grntracking");

            migrationBuilder.DropIndex(
                name: "IX_grntracking_grnuomid",
                table: "grntracking");

            migrationBuilder.DropColumn(
                name: "grncurrencyid",
                table: "grntracking");

            migrationBuilder.DropColumn(
                name: "grnunitprice",
                table: "grntracking");

            migrationBuilder.DropColumn(
                name: "grnuomid",
                table: "grntracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9140dae8-aa79-447b-94d2-565047d22bb8", "AQAAAAEAACcQAAAAEHmbC+1yxlCVWiuEVOu8xvnSTTAKNZETRUoLWlalKQ+P1lzWheVlTuU72zcG6PE4DQ==", "f87f9a3d-6cd7-4623-88a2-a7550d99f5f0" });
        }
    }
}
