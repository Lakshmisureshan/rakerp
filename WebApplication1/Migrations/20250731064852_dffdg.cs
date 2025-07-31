using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dffdg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "POOrderid",
                table: "Purchasedetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87694e23-4016-42ca-b4c1-67235e1a90ea", "AQAAAAEAACcQAAAAEM1AAQMbk+INDVDG1qIwKkcmXqJqW4zgZY+OOJRepUtH4WPgB0U0S3QgGIEDksD5pA==", "0c16713b-bcf3-458e-ad74-4ad14bb121c9" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_POOrderid",
                table: "Purchasedetails",
                column: "POOrderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasedetails_PO_POOrderid",
                table: "Purchasedetails",
                column: "POOrderid",
                principalTable: "PO",
                principalColumn: "Orderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchasedetails_PO_POOrderid",
                table: "Purchasedetails");

            migrationBuilder.DropIndex(
                name: "IX_Purchasedetails_POOrderid",
                table: "Purchasedetails");

            migrationBuilder.DropColumn(
                name: "POOrderid",
                table: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5a1fa74-e04c-42dc-9aa5-ebd253ab82bb", "AQAAAAEAACcQAAAAEEX86wljgyMQIBJ4sMDs6k397a8dTrpWF8ElW24cLDfl2wYC/63eHkefA/NtG4F2jQ==", "c466c479-ff19-4c9a-944a-9084069fd79c" });
        }
    }
}
