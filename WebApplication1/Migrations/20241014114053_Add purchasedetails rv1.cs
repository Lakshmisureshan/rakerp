using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addpurchasedetailsrv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "make",
                table: "Purchasedetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "pounitprice",
                table: "Purchasedetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59cc1171-8988-4ccf-9b79-6bd6cc7fd505", "AQAAAAEAACcQAAAAEDVRLhPSziXawE2xqagZeRa83tD7kHC45+TvM+e0Psr6AurEYidxim2nuxiDk2k1zA==", "223d4b72-1595-40b5-b6ed-a29405022d7c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "make",
                table: "Purchasedetails");

            migrationBuilder.DropColumn(
                name: "pounitprice",
                table: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72d48a72-2239-4d5c-865e-b2ff81c5590d", "AQAAAAEAACcQAAAAEM5rigDaeadhO7K32xXiCrkycmiNO4uFOGlgYMjt4Mdko44tczukvVcq1gGD+XjyIA==", "fa6b36ce-1f89-4fb9-934b-e49034abcebc" });
        }
    }
}
