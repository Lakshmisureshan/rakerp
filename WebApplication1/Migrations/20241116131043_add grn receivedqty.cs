using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addgrnreceivedqty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRNDetails",
                columns: table => new
                {
                    grntblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grnno = table.Column<int>(type: "int", nullable: false),
                    itemcode = table.Column<int>(type: "int", nullable: false),
                    grnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNDetails", x => x.grntblid);
                    table.ForeignKey(
                        name: "FK_GRNDetails_GRNHeader_grnno",
                        column: x => x.grnno,
                        principalTable: "GRNHeader",
                        principalColumn: "grnno");
                    table.ForeignKey(
                        name: "FK_GRNDetails_Product_itemcode",
                        column: x => x.itemcode,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a0d2bca-8ee0-4af4-867b-57aada77ad41", "AQAAAAEAACcQAAAAEBvUxDP2I43LZ5U9Mi3w+A/IRqV1Bl1u0gkkwJF84bevaJ7ASG3KVO3nMTOGIUNRgQ==", "af271ac8-0182-4d87-a641-4d28a312c4a9" });

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_grnno",
                table: "GRNDetails",
                column: "grnno");

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_itemcode",
                table: "GRNDetails",
                column: "itemcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRNDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3239e90-f89c-4a4e-b94b-a41adc599d80", "AQAAAAEAACcQAAAAEFh76skiX31QI7tABMlghNUseLNkZ2uaZ/lMLeCbCEwRClTpoy6qHZO2dIUawAQMIg==", "ea74dea8-b881-494c-973f-9bc054bd49ee" });
        }
    }
}
