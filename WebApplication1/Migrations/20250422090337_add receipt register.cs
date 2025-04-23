using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addreceiptregister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "receipt",
                columns: table => new
                {
                    rtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receiptid = table.Column<int>(type: "int", nullable: false),
                    invoiceid = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    amountinbasecurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Createdbyid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createdbydate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipt", x => x.rtblid);
                    table.ForeignKey(
                        name: "FK_receipt_AspNetUsers_Createdbyid",
                        column: x => x.Createdbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_receipt_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_receipt_Invoice_invoiceid",
                        column: x => x.invoiceid,
                        principalTable: "Invoice",
                        principalColumn: "invoiceno");
                    table.ForeignKey(
                        name: "FK_receipt_ReceiptVoucher_receiptid",
                        column: x => x.receiptid,
                        principalTable: "ReceiptVoucher",
                        principalColumn: "receiptid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65ecb364-6877-4f43-a85c-014e4e06dfb3", "AQAAAAEAACcQAAAAEEnRbNQp979w9mhICI5hl/c/b6ftdKWz6pJNr0J/2z2hpwli4hbEMCb0T7QdnnYhSQ==", "dda56a49-53aa-42a7-ac53-e19c2d4484d1" });

            migrationBuilder.CreateIndex(
                name: "IX_receipt_Createdbyid",
                table: "receipt",
                column: "Createdbyid");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_customerid",
                table: "receipt",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_invoiceid",
                table: "receipt",
                column: "invoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_receiptid",
                table: "receipt",
                column: "receiptid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "receipt");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b70dd617-29a2-434e-a601-b881a265a31b", "AQAAAAEAACcQAAAAEGe7ymDZS4zK5J+0c7hACotScrq4R7a7cgS2p88FP3SxoA/QHuPotV45+PhvNgJXRA==", "e8cf4ece-2a14-4ce2-b9cc-7bab4eebb3f9" });
        }
    }
}
