using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddBom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bom",
                columns: table => new
                {
                    bomid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    bomqty = table.Column<double>(type: "float", nullable: false),
                    bomuomid = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    prodstageid = table.Column<int>(type: "int", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bom", x => x.bomid);
                    table.ForeignKey(
                        name: "FK_Bom_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Bom_ProductionStages_prodstageid",
                        column: x => x.prodstageid,
                        principalTable: "ProductionStages",
                        principalColumn: "prostageid");
                    table.ForeignKey(
                        name: "FK_Bom_UOM_bomuomid",
                        column: x => x.bomuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f4549b9-1426-454f-a2e6-7b45a254f5ed", "AQAAAAEAACcQAAAAEEfvbr1gIY5vjDvTu+juieofjG7SPychducmy91LqNtnP2hfG0uSntRicH9kmGhqtg==", "61b7b7f5-ea6b-4cd2-80e2-8f64f51a02cb" });

            migrationBuilder.CreateIndex(
                name: "IX_Bom_bomuomid",
                table: "Bom",
                column: "bomuomid");

            migrationBuilder.CreateIndex(
                name: "IX_Bom_itemid",
                table: "Bom",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_Bom_prodstageid",
                table: "Bom",
                column: "prodstageid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bom");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4168f2bb-1edb-4d14-8ee0-807bded9f03d", "AQAAAAEAACcQAAAAEFKpduIi8V/q0il/QkFN0daqDeKDcRtXkqvkp2Ygnxg5CCYHzvdH8HOuZVUwrS7N+Q==", "75c57ee4-651d-425e-b031-27d75dee59f1" });
        }
    }
}
