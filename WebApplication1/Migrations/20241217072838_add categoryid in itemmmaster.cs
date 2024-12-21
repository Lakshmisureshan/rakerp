using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcategoryidinitemmmaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryid",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.Sql(@"
                UPDATE product
                SET categoryid = (SELECT TOP 1 categoryid FROM category)
                WHERE categoryid IS NOT NULL
                AND categoryid NOT IN (SELECT categoryid FROM category);
            ");








            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "397e23bb-36ef-4d7a-95a3-b715028f3ea9", "AQAAAAEAACcQAAAAEGJeBf9VCCLrcBUL0+3ZHyCo9tWXZ7b15g4oDnfGzNRNUVrn7oe/Q5cSesy9cUB2vw==", "de8a08e1-adb1-4ae3-bd5b-7b2436f461fc" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryid",
                table: "Product",
                column: "categoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_categoryid",
                table: "Product",
                column: "categoryid",
                principalTable: "Category",
                principalColumn: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_categoryid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_categoryid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "categoryid",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e65f3b4c-2f71-4472-9638-e23fe9bb4c0e", "AQAAAAEAACcQAAAAEB7gccJE00NLhk7uVQy039dSWro9xrKI4XYgQMf0nijKhF2MzeHuo1VHw0fuFUYv2A==", "de5c63ad-817f-4d4e-aea1-5eb2764e6232" });
        }
    }
}
