using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addbill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "billofentrydate",
                table: "Inventory",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "billofentryno",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "billofentrydate",
                table: "grntracking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "billofentryno",
                table: "grntracking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbf70549-2217-4ac8-bb74-7adb6a1b8cf6", "AQAAAAEAACcQAAAAEMVNfNR8G+ugZ70yK3STQdPebJmei1/nq23IWQh4qQTQltRNaTA6VLjO5b5gwZZmVQ==", "8fda55fd-a36a-4a05-a6d0-1ccbf850dbdc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "billofentrydate",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "billofentryno",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "billofentrydate",
                table: "grntracking");

            migrationBuilder.DropColumn(
                name: "billofentryno",
                table: "grntracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83fb056c-c9de-451a-8b3f-b5a00d1e4be5", "AQAAAAEAACcQAAAAEJ30nA3LhNos3JKOWyNHAlrOoROcgnnqj4w1YM6NABWqFc9nWETjzi+Ix7gyqWccVA==", "455d7175-41d4-462d-9985-0e3b3a2b8ba1" });
        }
    }
}
