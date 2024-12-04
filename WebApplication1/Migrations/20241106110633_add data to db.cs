using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatatodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedEntryDetails_Product_Productitemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedEntryDetails_Productitemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropColumn(
                name: "Productitemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc376a36-3747-40bb-9f63-e5dc3a1e1e9d", "AQAAAAEAACcQAAAAEP+AgXsF2M+oPM7O78wZwWJmmpubd+ekOiG9DECWWJl8u/Dytr7Skl692Lhm0NsiUA==", "b47113f7-4481-435f-b163-c15b401b91ae" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntryDetails_itemid",
                table: "ReceivedEntryDetails",
                column: "itemid");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedEntryDetails_Product_itemid",
                table: "ReceivedEntryDetails",
                column: "itemid",
                principalTable: "Product",
                principalColumn: "itemid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedEntryDetails_Product_itemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedEntryDetails_itemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.AddColumn<int>(
                name: "Productitemid",
                table: "ReceivedEntryDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98befd72-3683-4bf1-98f5-48a59add187a", "AQAAAAEAACcQAAAAEO/VVOWGsvQtdk6Inea0MS5tcKsAy/7eKaJzgXZDfH939vgITErQvZThVDjMBBwnLA==", "46444aba-372b-4cb8-91ca-8cd9883b587b" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntryDetails_Productitemid",
                table: "ReceivedEntryDetails",
                column: "Productitemid");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedEntryDetails_Product_Productitemid",
                table: "ReceivedEntryDetails",
                column: "Productitemid",
                principalTable: "Product",
                principalColumn: "itemid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
