using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addinvoicedetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoicedetails",
                columns: table => new
                {
                    invidno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceid = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    counter = table.Column<int>(type: "int", nullable: false),
                    vatpercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    taxamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoicedetails", x => x.invidno);
                    table.ForeignKey(
                        name: "FK_Invoicedetails_Invoice_invoiceid",
                        column: x => x.invoiceid,
                        principalTable: "Invoice",
                        principalColumn: "invoiceno");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0aaa0a8-f154-48a9-b06b-2974b20b3fee", "AQAAAAEAACcQAAAAEJvFnKt6hz9v2Gwfc8BrUCDxowlDHJ8qq8SAqRTvtlQ18mFNgLzj8SdohTrbl8azRQ==", "906b5352-48b7-4b7f-abed-08f6cf127d1f" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoicedetails_invoiceid",
                table: "Invoicedetails",
                column: "invoiceid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoicedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff5c2385-172f-4926-b367-d3e53c1b4fda", "AQAAAAEAACcQAAAAEKngXAk4YAf0JUCYgQWrnxVuxCnvgh9gR95X3t8htnZQrtFUNV3gtYT7/di7RNUQ5A==", "9b888930-8614-4ac7-af05-593e13bbc1ce" });
        }
    }
}
