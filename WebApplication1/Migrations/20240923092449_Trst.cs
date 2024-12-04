using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Trst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchasedetails_PO_POOrderid",
                table: "Purchasedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasedetails_Product_productitemid",
                table: "Purchasedetails");

            migrationBuilder.DropIndex(
                name: "IX_Purchasedetails_POOrderid",
                table: "Purchasedetails");

            migrationBuilder.DropIndex(
                name: "IX_Purchasedetails_productitemid",
                table: "Purchasedetails");

            migrationBuilder.DropColumn(
                name: "POOrderid",
                table: "Purchasedetails");

            migrationBuilder.DropColumn(
                name: "productitemid",
                table: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aad37553-69b4-4dbb-92af-5c01d7111775", "AQAAAAEAACcQAAAAENN7UcUnioiz2HiEJLzePkHRQWO3joeJmWW23PJ1IFtSdNcDx4Eo3uYeRNj+7o+kUg==", "d50039e8-382a-4a5f-b6fc-f141d8e82110" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_orderid",
                table: "Purchasedetails",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_poitemid",
                table: "Purchasedetails",
                column: "poitemid");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasedetails_PO_orderid",
                table: "Purchasedetails",
                column: "orderid",
                principalTable: "PO",
                principalColumn: "Orderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasedetails_Product_poitemid",
                table: "Purchasedetails",
                column: "poitemid",
                principalTable: "Product",
                principalColumn: "itemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchasedetails_PO_orderid",
                table: "Purchasedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasedetails_Product_poitemid",
                table: "Purchasedetails");

            migrationBuilder.DropIndex(
                name: "IX_Purchasedetails_orderid",
                table: "Purchasedetails");

            migrationBuilder.DropIndex(
                name: "IX_Purchasedetails_poitemid",
                table: "Purchasedetails");

            migrationBuilder.AddColumn<int>(
                name: "POOrderid",
                table: "Purchasedetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productitemid",
                table: "Purchasedetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "631f7bc0-3614-464e-ac4b-69c5e3fa04e8", "AQAAAAEAACcQAAAAEGb0GuP+W0ZsMhS197rbHK35ywlM4Ga9fnx065l/8aCnhXRA/D8CxLgh/48epJ1ZEg==", "89bc62d9-b60c-4496-9ad3-f1d4719271fd" });

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_POOrderid",
                table: "Purchasedetails",
                column: "POOrderid");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_productitemid",
                table: "Purchasedetails",
                column: "productitemid");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasedetails_PO_POOrderid",
                table: "Purchasedetails",
                column: "POOrderid",
                principalTable: "PO",
                principalColumn: "Orderid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasedetails_Product_productitemid",
                table: "Purchasedetails",
                column: "productitemid",
                principalTable: "Product",
                principalColumn: "itemid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
