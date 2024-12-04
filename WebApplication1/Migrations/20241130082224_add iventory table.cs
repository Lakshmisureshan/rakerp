using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addiventorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    invid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    batchid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<double>(type: "float", nullable: false),
                    Entrydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.invid);
                    table.ForeignKey(
                        name: "FK_Inventory_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Inventory_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                    table.ForeignKey(
                        name: "FK_Inventory_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Inventory_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "109167e7-d807-4207-a4e4-62a91ba4cd51", "AQAAAAEAACcQAAAAEJ+AbCaqr6hVlj1cMo4I7jRZovGXX1a4UWzgHsCj5AprroS0gkkPiQQoytUTIRnZDA==", "c62b5c55-546c-46e0-a8c9-be42c81ffcb9" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_jobid",
                table: "Inventory",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_pono",
                table: "Inventory",
                column: "pono");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_productid",
                table: "Inventory",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_uomid",
                table: "Inventory",
                column: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b343929-d2a1-4fd1-95b3-17fc0a7b1f6e", "AQAAAAEAACcQAAAAEETR2c807/OFKTdeofZbuPjPanYXzAcNv6zp8VByQB347cJ83hTO77sPxdjYR6RgaQ==", "3db062a6-97bf-4d0a-bd26-32d53c16c505" });
        }
    }
}
