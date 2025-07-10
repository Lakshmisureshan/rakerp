using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpreferrduom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Preferreduomperproducts",
                columns: table => new
                {
                    pid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prefuomid = table.Column<int>(type: "int", nullable: false),
                    multiplyfactor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    itemcode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferreduomperproducts", x => x.pid);
                    table.ForeignKey(
                        name: "FK_Preferreduomperproducts_Product_itemcode",
                        column: x => x.itemcode,
                        principalTable: "Product",
                        principalColumn: "productcode");
                    table.ForeignKey(
                        name: "FK_Preferreduomperproducts_UOM_prefuomid",
                        column: x => x.prefuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf48d2a8-3e72-4c96-868c-d6e696333a0e", "AQAAAAEAACcQAAAAEM4evz6W9nyRyl8Qfue8Kab1U4gF86H/2a83tdW9muvtzKa/1s2UYHzecj0Ziv3zaA==", "49119be1-5ee5-4b06-ab72-85dff93cbf27" });

            migrationBuilder.CreateIndex(
                name: "IX_Preferreduomperproducts_itemcode",
                table: "Preferreduomperproducts",
                column: "itemcode");

            migrationBuilder.CreateIndex(
                name: "IX_Preferreduomperproducts_prefuomid",
                table: "Preferreduomperproducts",
                column: "prefuomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preferreduomperproducts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8fb17b0-fa4c-446f-9b04-220f0d111f5c", "AQAAAAEAACcQAAAAEKLREZIwPeETy8pXFjG+YBN7DqybGCd3+i72kbN7ImnZCBD+VqwUjetsQoOAaFpgNg==", "83a489f6-c1f9-49e8-a48b-5809c1c498ea" });
        }
    }
}
