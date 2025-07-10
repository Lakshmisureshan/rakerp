using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addinvoicedteail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "invoiceno2",
                table: "Invoicedetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyFax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyTRN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceFormatNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClarificationContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClarificationDays = table.Column<int>(type: "int", nullable: false),
                    Bank1Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank1Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank1AEDAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank1USDAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank1SWIFT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank2Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank2Branch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank2AEDAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank2USDAccount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bank2SWIFT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfo", x => x.Id);
                });

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
                name: "FK_Invoicedetails_Invoice_invoiceno2",
                table: "Invoicedetails",
                column: "invoiceno2",
                principalTable: "Invoice",
                principalColumn: "invoiceno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno2",
                table: "Invoicedetails");

            migrationBuilder.DropTable(
                name: "CompanyInfo");

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
                values: new object[] { "5867d982-3f00-40fa-8c9d-9789789abe62", "AQAAAAEAACcQAAAAEKZahk65Actj+UYM7CnBJFRmcDvRS5SDMy8fzMPDBhIkY2L8mx0xylLYNH/+CWBwdQ==", "6afa509a-7ded-4e57-9a11-c4c142f573e8" });
        }
    }
}
