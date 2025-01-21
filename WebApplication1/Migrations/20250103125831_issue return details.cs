using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class issuereturndetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issuereturndetails",
                columns: table => new
                {
                    irtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    quantityreturned = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    issuereturnref = table.Column<int>(type: "int", nullable: false),
                    issuedetailtblid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuereturndetails", x => x.irtblid);
                    table.ForeignKey(
                        name: "FK_Issuereturndetails_IssuedetailsfromStock_issuedetailtblid",
                        column: x => x.issuedetailtblid,
                        principalTable: "IssuedetailsfromStock",
                        principalColumn: "issuedetailid");
                    table.ForeignKey(
                        name: "FK_Issuereturndetails_Issuereturn_issuereturnref",
                        column: x => x.issuereturnref,
                        principalTable: "Issuereturn",
                        principalColumn: "issuereturnref");
                    table.ForeignKey(
                        name: "FK_Issuereturndetails_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d7c8a24-bb78-4c7e-bb20-b6e6f30c0f15", "AQAAAAEAACcQAAAAEOo91gRlVG5IjeGkRvRsNus9dc2yXJPo9skB1yBeXwy8ThzUuEWV8xfIN+xr+4H/Rg==", "3943bf47-528a-4e62-8385-98098ee82e75" });

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_issuedetailtblid",
                table: "Issuereturndetails",
                column: "issuedetailtblid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_issuereturnref",
                table: "Issuereturndetails",
                column: "issuereturnref");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_productid",
                table: "Issuereturndetails",
                column: "productid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issuereturndetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b517eb57-c21f-42bc-8bde-11c8c82ce5d1", "AQAAAAEAACcQAAAAEB7Qbs25EEaUieGMjHoCpiVPZ00nW27R5EUBcY6JKLpFeUuUCoTwWSyNkYiUhHm57Q==", "5b421c29-691a-4a23-80ec-77fdea3c738d" });
        }
    }
}
