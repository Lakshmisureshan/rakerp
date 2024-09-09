using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addprdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRDetails",
                columns: table => new
                {
                    prtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prid = table.Column<int>(type: "int", nullable: false),
                    pritemid = table.Column<int>(type: "int", nullable: false),
                    bomid = table.Column<int>(type: "int", nullable: false),
                    prqty = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRDetails", x => x.prtblid);
                    table.ForeignKey(
                        name: "FK_PRDetails_Bom_bomid",
                        column: x => x.bomid,
                        principalTable: "Bom",
                        principalColumn: "bomid");
                    table.ForeignKey(
                        name: "FK_PRDetails_PR_prid",
                        column: x => x.prid,
                        principalTable: "PR",
                        principalColumn: "PRID");
                    table.ForeignKey(
                        name: "FK_PRDetails_Product_pritemid",
                        column: x => x.pritemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c95b50c9-49a9-4dc4-a4ce-aea31f8c42de", "AQAAAAEAACcQAAAAEOS2Vtl6R7cbxo3MEUcfkojq5sv2RUXO/6/hUf/TubAqvXSaCDrzqOjLFOjEzdvrlw==", "4691341d-9397-49b4-bccc-da32d75c37ff" });

            migrationBuilder.CreateIndex(
                name: "IX_PRDetails_bomid",
                table: "PRDetails",
                column: "bomid");

            migrationBuilder.CreateIndex(
                name: "IX_PRDetails_prid",
                table: "PRDetails",
                column: "prid");

            migrationBuilder.CreateIndex(
                name: "IX_PRDetails_pritemid",
                table: "PRDetails",
                column: "pritemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30ad8a34-f89b-4a17-b590-b9ea10973a76", "AQAAAAEAACcQAAAAEIeeRjzz4lz7djYGP0QyH+UH30kDf5bm3jDJofp6hqfQLMXKWX8fSlImpgjrIN3XPg==", "aeb28c49-0a17-4c0f-979d-4bf1da26779b" });
        }
    }
}
