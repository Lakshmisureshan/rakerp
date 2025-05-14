using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addgrnhraderdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "billofentrydate",
                table: "GRNHeader",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "billofentryno",
                table: "GRNHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dono",
                table: "GRNHeader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "remarks",
                table: "GRNHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57093d17-983b-4d5c-bc20-edb86591b434", "AQAAAAEAACcQAAAAECFsaKAax1TOhkRNVhPF8WTHGUlCLnIPrth3gqlBex2aPH4Swj63nZL0kkKiHy7W8w==", "0113782b-8cc0-4d3a-8941-9622df5a6d85" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "billofentrydate",
                table: "GRNHeader");

            migrationBuilder.DropColumn(
                name: "billofentryno",
                table: "GRNHeader");

            migrationBuilder.DropColumn(
                name: "dono",
                table: "GRNHeader");

            migrationBuilder.DropColumn(
                name: "remarks",
                table: "GRNHeader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0170bb4-3824-4248-a168-460d1911f78a", "AQAAAAEAACcQAAAAEPiulZd6dk3jr5p1KrlmBqzdCM0AOBzcTTFVfu7Kf9refsMxzS/q2WDRiVqE6qaVCA==", "9d583ae8-2548-4a62-93fd-fc04bb58433f" });
        }
    }
}
