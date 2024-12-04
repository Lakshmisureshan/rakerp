using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adduomidinpodetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<int>(
                name: "pouomid",
                table: "Purchasedetails",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.Sql(@"
                UPDATE purchasedetails
                SET pouomid = (SELECT TOP 1 uomid FROM UOM)
                WHERE pouomid IS NOT NULL
                AND pouomid NOT IN (SELECT uomid FROM UOM);
            ");















            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87fec879-5a20-44cc-9736-e55f0241e3e0", "AQAAAAEAACcQAAAAED1g/yYX7+eemACPLe2NSjhIeZ+rrfkgjfPyuTw/n129JUCnMcGHmWG/oN9Zkx6+MQ==", "9e6605ae-6802-4234-a5b5-a65161979298" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_pouomid",
                table: "Purchasedetails",
                column: "pouomid");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasedetails_UOM_pouomid",
                table: "Purchasedetails",
                column: "pouomid",
                principalTable: "UOM",
                principalColumn: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchasedetails_UOM_pouomid",
                table: "Purchasedetails");

            migrationBuilder.DropIndex(
                name: "IX_Purchasedetails_pouomid",
                table: "Purchasedetails");

            migrationBuilder.DropColumn(
                name: "pouomid",
                table: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7968b595-7140-426e-ab8a-cc44d8a0de18", "AQAAAAEAACcQAAAAEBnoZx0+5Z6hCH+ZKa00xDMFPYG0xJVuvovtULjUYE6DvEAVahHz0HGKE6Cm2zsN7A==", "0bbf8b3e-37c4-465d-8552-279f1a44b699" });
        }
    }
}
