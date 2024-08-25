using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "price",
                table: "Product",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71a1e7f0-59aa-4727-b364-d8d3f0c89bda", "AQAAAAEAACcQAAAAEHOCkRe/sRAzJotyOnGDFw5Qr5ijwtakWMjurDF+5zMBL+96pvEhRhfjK5RPLpnc8g==", "e954bdcc-5d32-404f-887e-fb4f971325fc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "454f3152-87c3-4891-9d27-78117fdf7e9b", "AQAAAAEAACcQAAAAEF7naOInNQrGk02p2wrqYGu38ZkubRm3lih+xI4Tnth9PbhP2yvavDkh4NLgLDYOKQ==", "7e1a7635-6053-4b17-abb9-7457c93351f8" });
        }
    }
}
