using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddfhjfdg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grntack");

            migrationBuilder.CreateTable(
                name: "grntracking",
                columns: table => new
                {
                    grntrackid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    grnno = table.Column<int>(type: "int", nullable: false),
                    grndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    grnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grntracking", x => x.grntrackid);
                    table.ForeignKey(
                        name: "FK_grntracking_GRNHeader_grnno",
                        column: x => x.grnno,
                        principalTable: "GRNHeader",
                        principalColumn: "grnno");
                    table.ForeignKey(
                        name: "FK_grntracking_Inventory_invid",
                        column: x => x.invid,
                        principalTable: "Inventory",
                        principalColumn: "invid");
                    table.ForeignKey(
                        name: "FK_grntracking_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_grntracking_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85cf3cf3-b7c5-4a6f-9c56-9fd0de565cba", "AQAAAAEAACcQAAAAEA9uDHft/xwUMEjJvCgrVbBDRZxLDB4nos9uAkUGz7qG4DlLVSh5N3x5kedXs5fF3g==", "8b50da5d-0cc8-4a5e-bc40-1e5cf493fe29" });

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_grnno",
                table: "grntracking",
                column: "grnno");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_invid",
                table: "grntracking",
                column: "invid");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_jobid",
                table: "grntracking",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_productid",
                table: "grntracking",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "grntracking");

            migrationBuilder.CreateTable(
                name: "grntack",
                columns: table => new
                {
                    grntrackid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grnno = table.Column<int>(type: "int", nullable: false),
                    invid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    grndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    grnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grntack", x => x.grntrackid);
                    table.ForeignKey(
                        name: "FK_grntack_GRNHeader_grnno",
                        column: x => x.grnno,
                        principalTable: "GRNHeader",
                        principalColumn: "grnno");
                    table.ForeignKey(
                        name: "FK_grntack_Inventory_invid",
                        column: x => x.invid,
                        principalTable: "Inventory",
                        principalColumn: "invid");
                    table.ForeignKey(
                        name: "FK_grntack_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_grntack_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "838c5cef-cfd3-4f3a-80ac-cde3c8d2d8b6", "AQAAAAEAACcQAAAAEPDme6kF7ZmnUfSZN+9Aesti6daYvVNQI8Dxyfu7+e4fouzl3832ArYwxqILZjcQgg==", "369caa59-a2b7-4d53-aa18-7c8e3368f828" });

            migrationBuilder.CreateIndex(
                name: "IX_grntack_grnno",
                table: "grntack",
                column: "grnno");

            migrationBuilder.CreateIndex(
                name: "IX_grntack_invid",
                table: "grntack",
                column: "invid");

            migrationBuilder.CreateIndex(
                name: "IX_grntack_jobid",
                table: "grntack",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_grntack_productid",
                table: "grntack",
                column: "productid");
        }
    }
}
