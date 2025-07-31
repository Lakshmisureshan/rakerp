using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dgfv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "billofentrydate",
                table: "issuereturntracking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "billofentryno",
                table: "issuereturntracking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5e30244-aeb5-4872-a809-3d710e6790f7", "AQAAAAEAACcQAAAAEMCtZ1HqYpwPmwliL9q/FjCaF4GaxCyQzZ/KJ35FMGeh4ColJ6VpANSJCAZ1V/rrBg==", "690e5f55-620b-49e1-8060-c35b50d795d6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "billofentrydate",
                table: "issuereturntracking");

            migrationBuilder.DropColumn(
                name: "billofentryno",
                table: "issuereturntracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad07df33-1b76-4a9e-bf79-c4a4d39ec602", "AQAAAAEAACcQAAAAEOH9EBg7v0FdRSgUVzLYwbCrxrsVJFVP3awVzHhK2yq5YfgWp2tHdui9tLu23okU1w==", "6c73c264-b6ae-4820-be47-fdbe4da2e2f6" });
        }
    }
}
