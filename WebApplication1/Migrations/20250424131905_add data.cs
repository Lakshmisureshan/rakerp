using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bom_Product_itemid",
                table: "Bom");

            migrationBuilder.DropForeignKey(
                name: "FK_estimation_Product_itemid",
                table: "estimation");

            migrationBuilder.DropForeignKey(
                name: "FK_GRNDetails_Product_itemcode",
                table: "GRNDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_grntracking_Product_productid",
                table: "grntracking");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_productid",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventoryreservation_Product_productid",
                table: "Inventoryreservation");

            migrationBuilder.DropForeignKey(
                name: "FK_IssuedetailsfromStock_Product_itemid",
                table: "IssuedetailsfromStock");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuenotedetails_Product_itemid",
                table: "Issuenotedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuereturndetails_Product_productid",
                table: "Issuereturndetails");

            migrationBuilder.DropForeignKey(
                name: "FK_issuereturntracking_Product_productid",
                table: "issuereturntracking");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuetracking_Product_productid",
                table: "Issuetracking");

            migrationBuilder.DropForeignKey(
                name: "FK_MIdetails_Product_itemid",
                table: "MIdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PRDetails_Product_pritemid",
                table: "PRDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasedetails_Product_poitemid",
                table: "Purchasedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedEntryDetails_Product_itemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UomMultiplyingFactor_Product_itemid",
                table: "UomMultiplyingFactor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "productcode");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56e9f896-56b7-4149-b812-02fba64b4964", "AQAAAAEAACcQAAAAENMJnyXiVz0DNY0uNnMiC8hwyPW4X3xfEK5kFD6587fvwmBRgvyEOVVygj7mLocJhQ==", "b87e499c-44ad-4c50-a780-2d8e1e18603b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bom_Product_itemid",
                table: "Bom",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_estimation_Product_itemid",
                table: "estimation",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_GRNDetails_Product_itemcode",
                table: "GRNDetails",
                column: "itemcode",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_grntracking_Product_productid",
                table: "grntracking",
                column: "productid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_productid",
                table: "Inventory",
                column: "productid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventoryreservation_Product_productid",
                table: "Inventoryreservation",
                column: "productid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedetailsfromStock_Product_itemid",
                table: "IssuedetailsfromStock",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuenotedetails_Product_itemid",
                table: "Issuenotedetails",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuereturndetails_Product_productid",
                table: "Issuereturndetails",
                column: "productid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_issuereturntracking_Product_productid",
                table: "issuereturntracking",
                column: "productid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuetracking_Product_productid",
                table: "Issuetracking",
                column: "productid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_MIdetails_Product_itemid",
                table: "MIdetails",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_PRDetails_Product_pritemid",
                table: "PRDetails",
                column: "pritemid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasedetails_Product_poitemid",
                table: "Purchasedetails",
                column: "poitemid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedEntryDetails_Product_itemid",
                table: "ReceivedEntryDetails",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "productcode");

            migrationBuilder.AddForeignKey(
                name: "FK_UomMultiplyingFactor_Product_itemid",
                table: "UomMultiplyingFactor",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "productcode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bom_Product_itemid",
                table: "Bom");

            migrationBuilder.DropForeignKey(
                name: "FK_estimation_Product_itemid",
                table: "estimation");

            migrationBuilder.DropForeignKey(
                name: "FK_GRNDetails_Product_itemcode",
                table: "GRNDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_grntracking_Product_productid",
                table: "grntracking");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_productid",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventoryreservation_Product_productid",
                table: "Inventoryreservation");

            migrationBuilder.DropForeignKey(
                name: "FK_IssuedetailsfromStock_Product_itemid",
                table: "IssuedetailsfromStock");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuenotedetails_Product_itemid",
                table: "Issuenotedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuereturndetails_Product_productid",
                table: "Issuereturndetails");

            migrationBuilder.DropForeignKey(
                name: "FK_issuereturntracking_Product_productid",
                table: "issuereturntracking");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuetracking_Product_productid",
                table: "Issuetracking");

            migrationBuilder.DropForeignKey(
                name: "FK_MIdetails_Product_itemid",
                table: "MIdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PRDetails_Product_pritemid",
                table: "PRDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchasedetails_Product_poitemid",
                table: "Purchasedetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedEntryDetails_Product_itemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UomMultiplyingFactor_Product_itemid",
                table: "UomMultiplyingFactor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "itemid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fd3518a-fd0d-4519-ac3a-435d7743804b", "AQAAAAEAACcQAAAAENxK8qTllbwgzZvLCkYra8DrQ13iCMyr4ZuXytGciiFGI1g+NNgHozQq4mEo3DNafg==", "07d53beb-6c03-4af7-8480-9a766d29512d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bom_Product_itemid",
                table: "Bom",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_estimation_Product_itemid",
                table: "estimation",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_GRNDetails_Product_itemcode",
                table: "GRNDetails",
                column: "itemcode",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_grntracking_Product_productid",
                table: "grntracking",
                column: "productid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_productid",
                table: "Inventory",
                column: "productid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventoryreservation_Product_productid",
                table: "Inventoryreservation",
                column: "productid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedetailsfromStock_Product_itemid",
                table: "IssuedetailsfromStock",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuenotedetails_Product_itemid",
                table: "Issuenotedetails",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuereturndetails_Product_productid",
                table: "Issuereturndetails",
                column: "productid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_issuereturntracking_Product_productid",
                table: "issuereturntracking",
                column: "productid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuetracking_Product_productid",
                table: "Issuetracking",
                column: "productid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_MIdetails_Product_itemid",
                table: "MIdetails",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_PRDetails_Product_pritemid",
                table: "PRDetails",
                column: "pritemid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchasedetails_Product_poitemid",
                table: "Purchasedetails",
                column: "poitemid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedEntryDetails_Product_itemid",
                table: "ReceivedEntryDetails",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_UomMultiplyingFactor_Product_itemid",
                table: "UomMultiplyingFactor",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "itemid");
        }
    }
}
