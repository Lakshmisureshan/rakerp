using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addreceivedentryqtyinpo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "receivedentryqty",
                table: "Purchasedetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d508f5bc-2102-42f0-970b-400c86d2205c", "AQAAAAEAACcQAAAAEM2o9W4e4gDNe/aPddgbqlbFRPbmslFVIEC/xCYB3Zc/t9gf4mv2ZPNYnI7MttOEYw==", "ccb4cbe1-7f05-44a9-af29-4c950208e0e6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receivedentryqty",
                table: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60d2d5a3-6832-4855-93ab-c4aead97c58a", "AQAAAAEAACcQAAAAEGUCnDYXJqx1A6UDCVguw7u7ZAH38TOGMMwXAkemfHdHODq/yGkrHBZ32yu2OM3Ntg==", "65783b0a-c35b-4c01-ba64-c5d5e393960a" });
        }
    }
}
