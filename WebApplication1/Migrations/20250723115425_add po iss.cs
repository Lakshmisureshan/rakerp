using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpoiss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POissuenotedetails");

            migrationBuilder.CreateTable(
                name: "POissuereturndetails",
                columns: table => new
                {
                    issuereturndetailid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issuereturnref = table.Column<int>(type: "int", nullable: false),
                    productcode = table.Column<int>(type: "int", nullable: false),
                    returnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    issuereturnunitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POissuereturndetails", x => x.issuereturndetailid);
                    table.ForeignKey(
                        name: "FK_POissuereturndetails_Issuereturn_issuereturnref",
                        column: x => x.issuereturnref,
                        principalTable: "Issuereturn",
                        principalColumn: "issuereturnref");
                    table.ForeignKey(
                        name: "FK_POissuereturndetails_Product_productcode",
                        column: x => x.productcode,
                        principalTable: "Product",
                        principalColumn: "productcode");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ed4972b-b974-4b30-bf3c-c087adf2b656", "AQAAAAEAACcQAAAAEAVZeMnooYg19uSKf0owzDrsLe5HX07DaEIPm5+suQ5Hcj4frixNX64Ri4YMTj2t/g==", "b8ae7fea-eb67-4c95-83ff-6f7670a67d0a" });

            migrationBuilder.CreateIndex(
                name: "IX_POissuereturndetails_issuereturnref",
                table: "POissuereturndetails",
                column: "issuereturnref");

            migrationBuilder.CreateIndex(
                name: "IX_POissuereturndetails_productcode",
                table: "POissuereturndetails",
                column: "productcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POissuereturndetails");

            migrationBuilder.CreateTable(
                name: "POissuenotedetails",
                columns: table => new
                {
                    issuereturndetailid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issuereturnref = table.Column<int>(type: "int", nullable: false),
                    productcode = table.Column<int>(type: "int", nullable: false),
                    issuereturnunitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    returnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POissuenotedetails", x => x.issuereturndetailid);
                    table.ForeignKey(
                        name: "FK_POissuenotedetails_Issuereturn_issuereturnref",
                        column: x => x.issuereturnref,
                        principalTable: "Issuereturn",
                        principalColumn: "issuereturnref");
                    table.ForeignKey(
                        name: "FK_POissuenotedetails_Product_productcode",
                        column: x => x.productcode,
                        principalTable: "Product",
                        principalColumn: "productcode");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5395af27-3f85-474e-a300-459d899e4b04", "AQAAAAEAACcQAAAAEE7D21M4Xx0Lpke0R8hMcKnFM/QViFo1SamdYEIhFWacUcSe6Ebzpv/tKbKZSvJAHQ==", "fead7957-00c0-4093-8142-2545b577c835" });

            migrationBuilder.CreateIndex(
                name: "IX_POissuenotedetails_issuereturnref",
                table: "POissuenotedetails",
                column: "issuereturnref");

            migrationBuilder.CreateIndex(
                name: "IX_POissuenotedetails_productcode",
                table: "POissuenotedetails",
                column: "productcode");
        }
    }
}
