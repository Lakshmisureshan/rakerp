using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsubcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "subcategoryid",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"
                UPDATE Product
                SET subcategoryid = (SELECT TOP 1 subcategoryid FROM subcategory);
             
            ");


            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42310d30-d91a-4565-918f-e69d4f2b5518", "AQAAAAEAACcQAAAAEKocBOOBUjvMDl2y1mH8YOfDiWsOfcq6kZsdQL9fWennivQLivTbchngUTiIfAPVeA==", "28d00519-a9eb-4f7c-b32c-94127990fe4a" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_subcategoryid",
                table: "Product",
                column: "subcategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_SubCategory_subcategoryid",
                table: "Product",
                column: "subcategoryid",
                principalTable: "SubCategory",
                principalColumn: "subcategoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_SubCategory_subcategoryid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_subcategoryid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "subcategoryid",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dca8a144-2ced-4cbc-bfbe-d39f75b3d51a", "AQAAAAEAACcQAAAAECEoTHFumyWLA8iXy2Aetgr5PQYVu0gns9RKBy9MJFO4FqNvUQR6F56XgvT6AdqwDg==", "e209d0ce-dd1c-41ba-a0a5-b1af4739f4e6" });
        }
    }
}
