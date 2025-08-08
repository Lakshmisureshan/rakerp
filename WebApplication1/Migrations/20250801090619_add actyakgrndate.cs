using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addactyakgrndate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "actualgrndate",
                table: "Inventory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "actualgrndate",
                table: "grntracking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae179dac-bc0e-4f4b-ae82-ec1223270d58", "AQAAAAEAACcQAAAAEGkTXplan29erfft2gmk9WjumWS+z077ryj4bMcDxYabkPsDwDp7rCNS+HY9KcO3jg==", "73e99d34-10a5-4cc2-8a8e-63f2b7387de2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actualgrndate",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "actualgrndate",
                table: "grntracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87694e23-4016-42ca-b4c1-67235e1a90ea", "AQAAAAEAACcQAAAAEM1AAQMbk+INDVDG1qIwKkcmXqJqW4zgZY+OOJRepUtH4WPgB0U0S3QgGIEDksD5pA==", "0c16713b-bcf3-458e-ad74-4ad14bb121c9" });
        }
    }
}
