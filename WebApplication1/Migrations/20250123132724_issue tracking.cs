using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class issuetracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "issuereturntracking",
                columns: table => new
                {
                    issuereturntrackid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    issuereturnno = table.Column<int>(type: "int", nullable: false),
                    issuereturndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    issuereturnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    issuereturnunitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    issuecurrencyid = table.Column<int>(type: "int", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issuereturntracking", x => x.issuereturntrackid);
                    table.ForeignKey(
                        name: "FK_issuereturntracking_Currency_issuecurrencyid",
                        column: x => x.issuecurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_issuereturntracking_Issuereturn_issuereturnno",
                        column: x => x.issuereturnno,
                        principalTable: "Issuereturn",
                        principalColumn: "issuereturnref");
                    table.ForeignKey(
                        name: "FK_issuereturntracking_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_issuereturntracking_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_issuereturntracking_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec09b2af-79ca-4ef4-b8af-de8f7966d011", "AQAAAAEAACcQAAAAEDH6GtkSR8D1/uBM6QEJy61w3R5cxPfxipMhfJhKz753nM23WqmjUwnBn9oZMi3KMQ==", "b98325cb-306f-4f4f-a2e3-a0235851fdaa" });

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_issuecurrencyid",
                table: "issuereturntracking",
                column: "issuecurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_issuereturnno",
                table: "issuereturntracking",
                column: "issuereturnno");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_jobid",
                table: "issuereturntracking",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_productid",
                table: "issuereturntracking",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_uomid",
                table: "issuereturntracking",
                column: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "issuereturntracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bf944ff-598c-4e3b-820b-d56c5708bedc", "AQAAAAEAACcQAAAAEErVpYJsCRSI1isUIoaiDZWLStDkLvULRuqGBCq4SIg9mbcMPrHEStjIj5LgEwvenw==", "930e31f0-2e70-4aa9-9976-f281604336c3" });
        }
    }
}
