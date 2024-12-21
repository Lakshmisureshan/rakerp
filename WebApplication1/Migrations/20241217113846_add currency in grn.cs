using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcurrencyingrn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "currencyid",
                table: "GRNHeader",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.Sql(@"
              UPDATE grnheader
SET currencyid = po.pocurrencyid
FROM po
WHERE grnheader.pono = po.orderid;
            ");





            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9e7eb43-9215-46c6-a05f-c09702222b6f", "AQAAAAEAACcQAAAAEB2vXdOlV47LNst8k8Z3PsH4/oHWFrlFOZUwC/Ti9Jd1UOOtfekeLlpnFXfgD401jQ==", "b3c376b2-d140-442a-bfa0-d0c3e93f1e92" });

            migrationBuilder.CreateIndex(
                name: "IX_GRNHeader_currencyid",
                table: "GRNHeader",
                column: "currencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_GRNHeader_Currency_currencyid",
                table: "GRNHeader",
                column: "currencyid",
                principalTable: "Currency",
                principalColumn: "currencyid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRNHeader_Currency_currencyid",
                table: "GRNHeader");

            migrationBuilder.DropIndex(
                name: "IX_GRNHeader_currencyid",
                table: "GRNHeader");

            migrationBuilder.DropColumn(
                name: "currencyid",
                table: "GRNHeader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397e23bb-36ef-4d7a-95a3-b715028f3ea9", "AQAAAAEAACcQAAAAEGJeBf9VCCLrcBUL0+3ZHyCo9tWXZ7b15g4oDnfGzNRNUVrn7oe/Q5cSesy9cUB2vw==", "de8a08e1-adb1-4ae3-bd5b-7b2436f461fc" });
        }
    }
}
