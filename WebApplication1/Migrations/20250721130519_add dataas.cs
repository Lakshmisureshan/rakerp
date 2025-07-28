using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddataas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryHistory",
                columns: table => new
                {
                    invidhist = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    batchid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Entrydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false),
                    invcurrencyid = table.Column<int>(type: "int", nullable: false),
                    invprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    reservedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryHistory", x => x.invidhist);
                    table.ForeignKey(
                        name: "FK_InventoryHistory_Currency_invcurrencyid",
                        column: x => x.invcurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_InventoryHistory_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_InventoryHistory_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                    table.ForeignKey(
                        name: "FK_InventoryHistory_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "productcode");
                    table.ForeignKey(
                        name: "FK_InventoryHistory_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09840ff2-ce05-42c1-bd1a-f1e43ce183b4", "AQAAAAEAACcQAAAAEOzs1t/i1PXzKL/MFiFZ2vhq5Qp1NCdwBVTz/wjTGt1y41hFbpDinVCVBR5rgnszrg==", "416b3df3-569e-4179-8797-ad1edbc172e4" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_invcurrencyid",
                table: "InventoryHistory",
                column: "invcurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_jobid",
                table: "InventoryHistory",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_pono",
                table: "InventoryHistory",
                column: "pono");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_productid",
                table: "InventoryHistory",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryHistory_uomid",
                table: "InventoryHistory",
                column: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryHistory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1cfad31-d322-4e5f-8150-dd99cc770e5f", "AQAAAAEAACcQAAAAEGZlVTLVA3h43oVa8JlcHYQ++wAxiyUvYkcFjYRDRSGvhEbw5iWtEC8CA148VO+bQw==", "4ec6514d-fddd-4460-bf6f-f5315ebf621f" });
        }
    }
}
