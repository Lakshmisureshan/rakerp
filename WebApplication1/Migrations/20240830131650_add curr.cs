using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcurr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "currencyid",
                table: "Bom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc735770-8690-4b17-b055-327ad14b32e3", "AQAAAAEAACcQAAAAEKlJNhRatei9+wTgrrRgEq15aJaTWVtszm3wpMS6P/CADajD16+Y1sP9bifCyUftIg==", "ced3df64-c6f1-4661-add3-f6cf9f9fae79" });

            migrationBuilder.CreateIndex(
                name: "IX_Bom_currencyid",
                table: "Bom",
                column: "currencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Bom_Currency_currencyid",
                table: "Bom",
                column: "currencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bom_Currency_currencyid",
                table: "Bom");

            migrationBuilder.DropIndex(
                name: "IX_Bom_currencyid",
                table: "Bom");

            migrationBuilder.DropColumn(
                name: "currencyid",
                table: "Bom");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f4549b9-1426-454f-a2e6-7b45a254f5ed", "AQAAAAEAACcQAAAAEEfvbr1gIY5vjDvTu+juieofjG7SPychducmy91LqNtnP2hfG0uSntRicH9kmGhqtg==", "61b7b7f5-ea6b-4cd2-80e2-8f64f51a02cb" });
        }
    }
}
