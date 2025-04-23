using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcheuedatetonull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "bankname",
                table: "ReceiptVoucher",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "160ea288-f3fb-4bb7-9e62-dd658fa9a2af", "AQAAAAEAACcQAAAAEOjP7JJl2anS3BVqRTpTLIX9fCgj3so4X+Cx6eyzmevLoc/cMck8LgepBhjR5h1Ihw==", "b8e52189-89cb-44af-bb18-7557a58726da" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "bankname",
                table: "ReceiptVoucher",
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
                values: new object[] { "01feb358-930b-40b0-b26f-64dfbd4ac23c", "AQAAAAEAACcQAAAAEEa5Db3yM68dzGVGA5WihyRPs0mJOgYFatR5nj1QNCLffJvYjVajknEYbjSVZihGLg==", "fc3be7bd-a603-48a9-b16c-008979490cdf" });
        }
    }
}
