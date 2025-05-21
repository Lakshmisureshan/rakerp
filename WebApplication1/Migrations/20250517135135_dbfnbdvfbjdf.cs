using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dbfnbdvfbjdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "createddate",
                table: "Company",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb809327-7fb5-4fdc-af49-7ead3fbca96a", "AQAAAAEAACcQAAAAEMMWjQJ3iGVSPcTTMq5t34HxcpjP01cl/NASfb8SLU+tpJOppPjnrM87hwuNnql/zg==", "1009c0e5-c15f-4108-894e-46e4c9c4f992" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "createddate",
                table: "Company",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46fbc0b8-8995-4697-ac4f-196cec66f0a5", "AQAAAAEAACcQAAAAEI8q3bWTDPhVOoWSHnA73Z9fOzVclLw4D9ib+VDorZyjKyzj/fJvAo6o9hYi2TJgSA==", "2da60a7c-8c30-48e0-bce4-41b32c125727" });
        }
    }
}
