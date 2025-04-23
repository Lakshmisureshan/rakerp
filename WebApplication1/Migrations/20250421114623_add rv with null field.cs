using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addrvwithnullfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cheque",
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
                values: new object[] { "01feb358-930b-40b0-b26f-64dfbd4ac23c", "AQAAAAEAACcQAAAAEEa5Db3yM68dzGVGA5WihyRPs0mJOgYFatR5nj1QNCLffJvYjVajknEYbjSVZihGLg==", "fc3be7bd-a603-48a9-b16c-008979490cdf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cheque",
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
                values: new object[] { "451eb326-d032-4977-9649-79c87cb2e2ff", "AQAAAAEAACcQAAAAEH1K+lrY6O0OIKkbH6pdvBpY3MaljgevsiFfLevz/MwM3WXrduUk+rarSLJVmX1isw==", "12a60476-b080-40e7-9667-594db91e56ef" });
        }
    }
}
