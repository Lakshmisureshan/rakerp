using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddInventorymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventoryreservation",
                columns: table => new
                {
                    RId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inventoryid = table.Column<int>(type: "int", nullable: false),
                    fromjobid = table.Column<int>(type: "int", nullable: false),
                    tojobid = table.Column<int>(type: "int", nullable: false),
                    reservedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventoryreservation", x => x.RId);
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Inventory_inventoryid",
                        column: x => x.inventoryid,
                        principalTable: "Inventory",
                        principalColumn: "invid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Job_fromjobid",
                        column: x => x.fromjobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Job_tojobid",
                        column: x => x.tojobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae5eaec0-ec33-49d2-9c7d-1cf30302f304", "AQAAAAEAACcQAAAAEB0ZWXN/niPjKjE6DrtytZ8Lu9IolCz5/+3BvzTqxmFb3OCibL1DoG5p/ItaIHwLJA==", "cd0323f8-b81d-4c36-bf56-32cc5994a295" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_fromjobid",
                table: "Inventoryreservation",
                column: "fromjobid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_inventoryid",
                table: "Inventoryreservation",
                column: "inventoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_productid",
                table: "Inventoryreservation",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_tojobid",
                table: "Inventoryreservation",
                column: "tojobid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_uomid",
                table: "Inventoryreservation",
                column: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventoryreservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2d135f4-2527-44ac-80d6-d18571beeb09", "AQAAAAEAACcQAAAAEGq9ZfXDLZvn0mZQtWceqNYzbp1TU5CpRnFQrBZMIsxzL9TESIXy/YmzflferSC0LA==", "5e898580-1769-472d-8d05-59e3a1de77b9" });
        }
    }
}
