using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchasedetails",
                columns: table => new
                {
                    potblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POOrderid = table.Column<int>(type: "int", nullable: false),
                    orderid = table.Column<int>(type: "int", nullable: false),
                    productitemid = table.Column<int>(type: "int", nullable: false),
                    poitemid = table.Column<int>(type: "int", nullable: false),
                    poquantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchasedetails", x => x.potblid);
                    table.ForeignKey(
                        name: "FK_Purchasedetails_PO_POOrderid",
                        column: x => x.POOrderid,
                        principalTable: "PO",
                        principalColumn: "Orderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchasedetails_Product_productitemid",
                        column: x => x.productitemid,
                        principalTable: "Product",
                        principalColumn: "itemid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRPO",
                columns: table => new
                {
                    Purchasedetailspotblid = table.Column<int>(type: "int", nullable: false),
                    prdetailsprtblid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRPO", x => new { x.Purchasedetailspotblid, x.prdetailsprtblid });
                    table.ForeignKey(
                        name: "FK_PRPO_PRDetails_prdetailsprtblid",
                        column: x => x.prdetailsprtblid,
                        principalTable: "PRDetails",
                        principalColumn: "prtblid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRPO_Purchasedetails_Purchasedetailspotblid",
                        column: x => x.Purchasedetailspotblid,
                        principalTable: "Purchasedetails",
                        principalColumn: "potblid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "631f7bc0-3614-464e-ac4b-69c5e3fa04e8", "AQAAAAEAACcQAAAAEGb0GuP+W0ZsMhS197rbHK35ywlM4Ga9fnx065l/8aCnhXRA/D8CxLgh/48epJ1ZEg==", "89bc62d9-b60c-4496-9ad3-f1d4719271fd" });

            migrationBuilder.CreateIndex(
                name: "IX_PRPO_prdetailsprtblid",
                table: "PRPO",
                column: "prdetailsprtblid");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_POOrderid",
                table: "Purchasedetails",
                column: "POOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_productitemid",
                table: "Purchasedetails",
                column: "productitemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRPO");

            migrationBuilder.DropTable(
                name: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce5be5b5-7407-4e5e-b2b8-c555538e85b4", "AQAAAAEAACcQAAAAEOJGBn6pcHx4BbSY7TwjSZCP8KhDw9Y70HZMXexmk1xmE+yRerkr4KMPEbP6157TGQ==", "3b444c44-ea6f-49f2-97b1-7f37de1006fd" });
        }
    }
}
