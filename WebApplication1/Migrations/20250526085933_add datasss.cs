using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatasss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno",
                table: "Invoicedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno2",
                table: "Invoicedetails");

            migrationBuilder.DropIndex(
                name: "IX_Invoicedetails_invoiceno2",
                table: "Invoicedetails");

            migrationBuilder.DropColumn(
                name: "invoiceno2",
                table: "Invoicedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c84de57-5ae2-435a-8489-a049a782bad3", "AQAAAAEAACcQAAAAEMJWP0gwGAVpJuXpR7X/44cZpmzJ5x8N/55rplGHEfIc84VKJ1729RIWizhgHu6J7w==", "da7bdec1-c75e-47b0-bd6b-b7e1ae7893f6" });

            migrationBuilder.AddForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno",
                table: "Invoicedetails",
                column: "invoiceno",
                principalTable: "Invoice",
                principalColumn: "invoiceno",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno",
                table: "Invoicedetails");

            migrationBuilder.AddColumn<int>(
                name: "invoiceno2",
                table: "Invoicedetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f683e40a-72b2-48a7-a266-1cd204d75d0f", "AQAAAAEAACcQAAAAEDedvz3pC9M53OmOItO94/D3gO4D5XF1m/OYcBwmClWZxS9vSGtRwr5XN5bpUk9Yjg==", "d94ea797-44eb-452a-86ba-9e1cf2f1c462" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoicedetails_invoiceno2",
                table: "Invoicedetails",
                column: "invoiceno2");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno",
                table: "Invoicedetails",
                column: "invoiceno",
                principalTable: "Invoice",
                principalColumn: "invoiceno");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno2",
                table: "Invoicedetails",
                column: "invoiceno2",
                principalTable: "Invoice",
                principalColumn: "invoiceno");
        }
    }
}
