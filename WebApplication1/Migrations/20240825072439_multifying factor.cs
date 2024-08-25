using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class multifyingfactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    itemid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemdescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.itemid);
                });

            migrationBuilder.CreateTable(
                name: "UOM",
                columns: table => new
                {
                    uomid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uomname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOM", x => x.uomid);
                });

            migrationBuilder.CreateTable(
                name: "UomMultiplyingFactor",
                columns: table => new
                {
                    muid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    fromuomid = table.Column<int>(type: "int", nullable: false),
                    touomid = table.Column<int>(type: "int", nullable: false),
                    conversionfactor = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UomMultiplyingFactor", x => x.muid);
                    table.ForeignKey(
                        name: "FK_UomMultiplyingFactor_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_UomMultiplyingFactor_UOM_fromuomid",
                        column: x => x.fromuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                    table.ForeignKey(
                        name: "FK_UomMultiplyingFactor_UOM_touomid",
                        column: x => x.touomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "454f3152-87c3-4891-9d27-78117fdf7e9b", "AQAAAAEAACcQAAAAEF7naOInNQrGk02p2wrqYGu38ZkubRm3lih+xI4Tnth9PbhP2yvavDkh4NLgLDYOKQ==", "7e1a7635-6053-4b17-abb9-7457c93351f8" });

            migrationBuilder.CreateIndex(
                name: "IX_UomMultiplyingFactor_fromuomid",
                table: "UomMultiplyingFactor",
                column: "fromuomid");

            migrationBuilder.CreateIndex(
                name: "IX_UomMultiplyingFactor_itemid",
                table: "UomMultiplyingFactor",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_UomMultiplyingFactor_touomid",
                table: "UomMultiplyingFactor",
                column: "touomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UomMultiplyingFactor");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "UOM");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac241ec0-c0e5-4174-932f-4baf8024afa0", "AQAAAAEAACcQAAAAEBJHouThnCFoWkp/nITCFNWO2GzAD6XcxOL68L1bz1QCkhCbu5GEqo0you0Mhm4SXg==", "c76243c0-dfb6-4fa1-8ced-4ed912d0903c" });
        }
    }
}
