using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addherferber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "invcurrencyid",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e85f709-e65b-42e3-b224-3503bc8552ca", "AQAAAAEAACcQAAAAEB7quOrgM2CMTS7vWodJxKQlhERZikAdFVxP9qe/Qah3GgbEbCrNTB5DuF/6dgcIMQ==", "faf1eadf-d428-46f1-8126-f614f61e5949" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_invcurrencyid",
                table: "Invoice",
                column: "invcurrencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Currency_invcurrencyid",
                table: "Invoice",
                column: "invcurrencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Currency_invcurrencyid",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_invcurrencyid",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "invcurrencyid",
                table: "Invoice");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "131a0561-12b0-4850-8ce0-b79e6fff4b05", "AQAAAAEAACcQAAAAEANLCfO/giiu6I6+xhv9U5RquWynhigtv3+x2FrX3hohVEkkmGfoo3nHqrwWfOWvfg==", "628778f1-cd18-419e-91c9-6f1de4baba4c" });
        }
    }
}
