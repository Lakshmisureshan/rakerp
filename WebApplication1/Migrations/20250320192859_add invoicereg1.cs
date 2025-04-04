using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addinvoicereg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceReg_AspNetUsers_applicationUserId",
                table: "InvoiceReg");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceReg_applicationUserId",
                table: "InvoiceReg");

            migrationBuilder.DropColumn(
                name: "applicationUserId",
                table: "InvoiceReg");

            migrationBuilder.AlterColumn<string>(
                name: "Invoiceregisteredby",
                table: "InvoiceReg",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "973dbf2e-4a13-467a-8f56-ebc3fe289fdf", "AQAAAAEAACcQAAAAELIhRJ1SD/uUTg9sXhrI/4YrRPw9+DrlUvqhpI/3gEoHqoVLB1xLLASwPzDeEjWc6A==", "3a1c03ec-2a1d-4554-9d41-c00e9d23cea1" });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReg_Invoiceregisteredby",
                table: "InvoiceReg",
                column: "Invoiceregisteredby");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceReg_AspNetUsers_Invoiceregisteredby",
                table: "InvoiceReg",
                column: "Invoiceregisteredby",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceReg_AspNetUsers_Invoiceregisteredby",
                table: "InvoiceReg");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceReg_Invoiceregisteredby",
                table: "InvoiceReg");

            migrationBuilder.AlterColumn<string>(
                name: "Invoiceregisteredby",
                table: "InvoiceReg",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "applicationUserId",
                table: "InvoiceReg",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "003cd071-2676-4f55-ba9a-10bfde4d9b44", "AQAAAAEAACcQAAAAEHf31SOZ3y7PYkMaoHplC20/4mUlopHrKc5VlQrQ+qLIga1D66Iolyw8F/mZsdtYBA==", "e9d8fdbe-b2bd-433f-b5a1-3d357829261b" });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReg_applicationUserId",
                table: "InvoiceReg",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceReg_AspNetUsers_applicationUserId",
                table: "InvoiceReg",
                column: "applicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
