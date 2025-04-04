using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addInvoicePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    invoiceno = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LPOno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LPODate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.invoiceno);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_Invoice_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9c17bc7-4d19-4ceb-b3cf-9579e2049770", "AQAAAAEAACcQAAAAEAtZG+gBQMjuCQa9B05qbKbfuW8oD4o6blwkdWEPl0bKhidr4v6RhN/cSxLeYjAs6A==", "5475214b-877a-4a06-b1b5-011b26f16f32" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_customerid",
                table: "Invoice",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_jobid",
                table: "Invoice",
                column: "jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4259fa44-211c-4a50-939f-7fc4f61b0007", "AQAAAAEAACcQAAAAELe/XTGyLTDGc2VE1VLfnkoQTENn/+xCp+8Q1O5+JADTjhvbLAivo2tV4GhOYC7L1A==", "d352eb5c-2b90-485d-acce-679417fd46d9" });
        }
    }
}
