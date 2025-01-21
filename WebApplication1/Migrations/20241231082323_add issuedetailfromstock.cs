using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuedetailfromstock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssuedetailsfromStock",
                columns: table => new
                {
                    issuedetailid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issuenoteref = table.Column<int>(type: "int", nullable: false),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    issueqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rid = table.Column<int>(type: "int", nullable: false),
                    issueprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedetailsfromStock", x => x.issuedetailid);
                    table.ForeignKey(
                        name: "FK_IssuedetailsfromStock_Inventoryreservation_rid",
                        column: x => x.rid,
                        principalTable: "Inventoryreservation",
                        principalColumn: "RId");
                    table.ForeignKey(
                        name: "FK_IssuedetailsfromStock_IssueNoteheader_issuenoteref",
                        column: x => x.issuenoteref,
                        principalTable: "IssueNoteheader",
                        principalColumn: "issueref");
                    table.ForeignKey(
                        name: "FK_IssuedetailsfromStock_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a54d106a-844e-4853-ac42-373b407e2f4b", "AQAAAAEAACcQAAAAEDt/E6h/7mNChYwtR4rxFV0IeVOsaOHeZU71ytBJOwEQrvXcBftgc5qiMfGJWWOgNw==", "0e255ae8-0964-4f64-906d-7ebe87167305" });

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_issuenoteref",
                table: "IssuedetailsfromStock",
                column: "issuenoteref");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_itemid",
                table: "IssuedetailsfromStock",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_rid",
                table: "IssuedetailsfromStock",
                column: "rid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuedetailsfromStock");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30626941-c9a4-4fc7-80a1-b9f8343d6df0", "AQAAAAEAACcQAAAAEBcdEoJb7WS/j77lQ+RzeCReq0YVHKaS3nu8t0+O91ns5ISgyWC/0j0dIBP4QWA9rg==", "0779cc05-231b-4881-8b7d-684b0e28f3fe" });
        }
    }
}
