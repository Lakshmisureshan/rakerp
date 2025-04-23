using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addrv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceiptVoucher",
                columns: table => new
                {
                    receiptid = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    rvcurrencyid = table.Column<int>(type: "int", nullable: false),
                    rvexchangerate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rvamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rvamountaed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rvamountwords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cheque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    chequedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bankname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiptdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rvreamrks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isregistered = table.Column<int>(type: "int", nullable: false),
                    createdbyid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptVoucher", x => x.receiptid);
                    table.ForeignKey(
                        name: "FK_ReceiptVoucher_AspNetUsers_createdbyid",
                        column: x => x.createdbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReceiptVoucher_Currency_rvcurrencyid",
                        column: x => x.rvcurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_ReceiptVoucher_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "451eb326-d032-4977-9649-79c87cb2e2ff", "AQAAAAEAACcQAAAAEH1K+lrY6O0OIKkbH6pdvBpY3MaljgevsiFfLevz/MwM3WXrduUk+rarSLJVmX1isw==", "12a60476-b080-40e7-9667-594db91e56ef" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVoucher_createdbyid",
                table: "ReceiptVoucher",
                column: "createdbyid");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVoucher_customerid",
                table: "ReceiptVoucher",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVoucher_rvcurrencyid",
                table: "ReceiptVoucher",
                column: "rvcurrencyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptVoucher");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55264069-bdb7-4302-b380-d791c55909fa", "AQAAAAEAACcQAAAAEFYzHcAlPGJdgQg5SDRQZ20pWD967hxNDSaKtPNLNK7payYayMhW7Wzb6yBrUfmQwQ==", "94e1770e-730f-465a-915e-e0f32254c30e" });
        }
    }
}
