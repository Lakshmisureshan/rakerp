using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addestimation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estimation",
                columns: table => new
                {
                    estimationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    applicationid = table.Column<int>(type: "int", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false),
                    currencyid = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estimation", x => x.estimationid);
                    table.ForeignKey(
                        name: "FK_estimation_Currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_estimation_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_estimation_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_estimation_ProductionStages_applicationid",
                        column: x => x.applicationid,
                        principalTable: "ProductionStages",
                        principalColumn: "prostageid");
                    table.ForeignKey(
                        name: "FK_estimation_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96a8c5bc-f489-49d9-99fc-d6cc580a2332", "AQAAAAEAACcQAAAAEMWWxi48TKmTf0/MdSjW80d0V4otYfjZclje9CEx3zBGQqYV1I1NbvhS0yVTmOL7vg==", "64f40e8d-bbb8-4902-a565-fbc1bbb921e4" });

            migrationBuilder.CreateIndex(
                name: "IX_estimation_applicationid",
                table: "estimation",
                column: "applicationid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_currencyid",
                table: "estimation",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_itemid",
                table: "estimation",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_jobid",
                table: "estimation",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_uomid",
                table: "estimation",
                column: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estimation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f51655d-668b-48ed-ac59-d95690c19957", "AQAAAAEAACcQAAAAEO1hcOwtmVNRpW35ahKtqjEP1vbMSv35AWw8c+QsNkCaDuouzYiaFHcMdzi+HijRqg==", "f3791a64-ace9-40cd-ba82-bb9daec6b167" });
        }
    }
}
