using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatasdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POissuenotedetails",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POissuenotedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed2b6fc-5494-452b-8947-310775658962", "AQAAAAEAACcQAAAAEBH6XuHNkt/COE/z2kqxmRHN1MoaSWtbvs52omsEkrxtMDqk6qn20rL+uRWUw1c/Tg==", "ae7131b2-7855-4fa6-98c2-3b297a27c08c" });
        }
    }
}
