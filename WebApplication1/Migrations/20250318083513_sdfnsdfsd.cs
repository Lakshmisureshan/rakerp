using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class sdfnsdfsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno1",
                table: "Invoicedetails");

            migrationBuilder.DropIndex(
                name: "IX_Invoicedetails_invoiceno1",
                table: "Invoicedetails");

            migrationBuilder.DropColumn(
                name: "invoiceno1",
                table: "Invoicedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "431e37fa-b432-45df-8921-3e0cdba8b70b", "AQAAAAEAACcQAAAAELzhCDj2qWlXq7DYe8BMk/67wvB5rGtBbMuaEvPCWNU4kMoVjezpbMVfrC3pjEUBSQ==", "e8141e08-239f-46d8-8995-fdbb03490ef1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "invoiceno1",
                table: "Invoicedetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4dc01b6-60eb-4a06-ab1d-082c4abb925c", "AQAAAAEAACcQAAAAENVplZFfrfZsgNf1/7sIWw7RJQXGzC4AH2j670sbls7HLcttuYx8MFBP+gkGs4c2fw==", "5c9ec191-cfe3-42b1-94c3-2bdc92c2b836" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoicedetails_invoiceno1",
                table: "Invoicedetails",
                column: "invoiceno1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno1",
                table: "Invoicedetails",
                column: "invoiceno1",
                principalTable: "Invoice",
                principalColumn: "invoiceno");
        }
    }
}
