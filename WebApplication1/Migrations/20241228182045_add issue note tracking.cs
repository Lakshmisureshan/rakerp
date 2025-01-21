using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuenotetracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issuetracking",
                columns: table => new
                {
                    issuetrackid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    issuenoteno = table.Column<int>(type: "int", nullable: false),
                    issuedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    issueqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuetracking", x => x.issuetrackid);
                    table.ForeignKey(
                        name: "FK_Issuetracking_Inventory_invid",
                        column: x => x.invid,
                        principalTable: "Inventory",
                        principalColumn: "invid");
                    table.ForeignKey(
                        name: "FK_Issuetracking_IssueNoteheader_issuenoteno",
                        column: x => x.issuenoteno,
                        principalTable: "IssueNoteheader",
                        principalColumn: "issueref");
                    table.ForeignKey(
                        name: "FK_Issuetracking_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Issuetracking_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5676ebb0-1362-4587-8dda-3befa3757e0b", "AQAAAAEAACcQAAAAEJIUAjtywdhjhsvX7bnw2vL4utDz7WRhYhz83BOeeoOVBuMoD18LoWL+PxNf3Yl2wg==", "a604df87-046c-4d07-8c83-dc69aea4f1cf" });

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_invid",
                table: "Issuetracking",
                column: "invid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_issuenoteno",
                table: "Issuetracking",
                column: "issuenoteno");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_jobid",
                table: "Issuetracking",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_productid",
                table: "Issuetracking",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issuetracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85cf3cf3-b7c5-4a6f-9c56-9fd0de565cba", "AQAAAAEAACcQAAAAEA9uDHft/xwUMEjJvCgrVbBDRZxLDB4nos9uAkUGz7qG4DlLVSh5N3x5kedXs5fF3g==", "8b50da5d-0cc8-4a5e-bc40-1e5cf493fe29" });
        }
    }
}
