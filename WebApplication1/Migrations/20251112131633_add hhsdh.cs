using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addhhsdh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Joborderentry",
                columns: table => new
                {
                    jobentryidno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enquiryref = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    projectname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enduserid = table.Column<int>(type: "int", nullable: false),
                    jobdescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ordervalue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ordervaluecurrencyid = table.Column<int>(type: "int", nullable: false),
                    enduservlaue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    enduservaluecurrencyid = table.Column<int>(type: "int", nullable: false),
                    warrantyterms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentterms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joborderentry", x => x.jobentryidno);
                    table.ForeignKey(
                        name: "FK_Joborderentry_Currency_enduservaluecurrencyid",
                        column: x => x.enduservaluecurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Joborderentry_Currency_ordervaluecurrencyid",
                        column: x => x.ordervaluecurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Joborderentry_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_Joborderentry_Customer_enduserid",
                        column: x => x.enduserid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_Joborderentry_Enquiry_Enquiryref",
                        column: x => x.Enquiryref,
                        principalTable: "Enquiry",
                        principalColumn: "Enquiryref");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31407712-a247-4a3e-91e4-6254e981ec5f", "AQAAAAEAACcQAAAAEFDgmzIkfxgGWWOQq7ci7vN10JKYZr4ZYbx5JNLllDPOYwyEmaU+ijHI6Du5xdjU2A==", "dce7dc16-67d8-4380-bef4-d78c8dd2af1a" });

            migrationBuilder.CreateIndex(
                name: "IX_Joborderentry_customerid",
                table: "Joborderentry",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Joborderentry_enduserid",
                table: "Joborderentry",
                column: "enduserid");

            migrationBuilder.CreateIndex(
                name: "IX_Joborderentry_enduservaluecurrencyid",
                table: "Joborderentry",
                column: "enduservaluecurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Joborderentry_Enquiryref",
                table: "Joborderentry",
                column: "Enquiryref");

            migrationBuilder.CreateIndex(
                name: "IX_Joborderentry_ordervaluecurrencyid",
                table: "Joborderentry",
                column: "ordervaluecurrencyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Joborderentry");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "776acd22-f0ef-49bf-a125-94cc03c067a5", "AQAAAAEAACcQAAAAEFmm7jXtjASqBpBr6vp7VEULmGoIOEH15VMlw0K0Pqb7SAdtS/GEe4e8dPSWk99pXQ==", "98589c87-c115-4937-893c-44fa0e6516e1" });
        }
    }
}
