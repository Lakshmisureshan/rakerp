using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmidetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MIdetails",
                columns: table => new
                {
                    mitblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mid = table.Column<int>(type: "int", nullable: false),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    acceptedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rejectedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    holdqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MIdetails", x => x.mitblid);
                    table.ForeignKey(
                        name: "FK_MIdetails_Materialinspection_mid",
                        column: x => x.mid,
                        principalTable: "Materialinspection",
                        principalColumn: "mid");
                    table.ForeignKey(
                        name: "FK_MIdetails_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bab6e432-8da3-4d2c-aef9-dd9df10d5628", "AQAAAAEAACcQAAAAEFW/PzBTm4Vv+ze/mFI/j1Y3/uFa7WiTknVmFnVsXejXH1ldvvnDAQZkQt2pVOv0vw==", "6f36a713-a8e2-4e71-bdbe-27fc4fceba22" });

            migrationBuilder.CreateIndex(
                name: "IX_MIdetails_itemid",
                table: "MIdetails",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_MIdetails_mid",
                table: "MIdetails",
                column: "mid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MIdetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16c87ea8-64c5-4dbe-aefa-e7146bff7fe2", "AQAAAAEAACcQAAAAEDsXH53wbuXDJN+PC/z6eqn3YC6GqE1XeVNlj/rKUufugzWQARgfoL/bw/obmykYpg==", "e49ceb4a-e691-4c37-abc4-ddfb81562009" });
        }
    }
}
