using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AdduominProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "standarduomid",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5e6b0d6-d915-45e4-a272-8f354926e202", "AQAAAAEAACcQAAAAEFuIzncf3VG5PLQy9FVWgE5jMkEM5I1awDGlT+SfgpArwF0FL/X/oVyNvvuzoX8vMw==", "917d6da9-a214-4d7c-910f-d796abc341be" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_standarduomid",
                table: "Product",
                column: "standarduomid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_UOM_standarduomid",
                table: "Product",
                column: "standarduomid",
                principalTable: "UOM",
                principalColumn: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_UOM_standarduomid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_standarduomid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "standarduomid",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71a1e7f0-59aa-4727-b364-d8d3f0c89bda", "AQAAAAEAACcQAAAAEHOCkRe/sRAzJotyOnGDFw5Qr5ijwtakWMjurDF+5zMBL+96pvEhRhfjK5RPLpnc8g==", "e954bdcc-5d32-404f-887e-fb4f971325fc" });
        }
    }
}
