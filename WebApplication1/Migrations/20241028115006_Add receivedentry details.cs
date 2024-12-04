using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addreceivedentrydetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "location",
                table: "ReceivedEntry",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "ReceivedEntry",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60d2d5a3-6832-4855-93ab-c4aead97c58a", "AQAAAAEAACcQAAAAEGUCnDYXJqx1A6UDCVguw7u7ZAH38TOGMMwXAkemfHdHODq/yGkrHBZ32yu2OM3Ntg==", "65783b0a-c35b-4c01-ba64-c5d5e393960a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "location",
                table: "ReceivedEntry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "ReceivedEntry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9c65826-055f-4742-ae90-80337defccd9", "AQAAAAEAACcQAAAAEHn/px3C4kA0xDZ+LLcK5l/pGISm2kmD5U1eX4vevIeTGqAtEECWLgz2Y8NiQnnsCw==", "47351ef9-fbb7-410d-ad75-6903cbacc06c" });
        }
    }
}
