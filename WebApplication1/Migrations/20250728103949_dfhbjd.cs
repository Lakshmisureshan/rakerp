using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dfhbjd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "billofentrydate",
                table: "Issuetracking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "billofentryno",
                table: "Issuetracking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad07df33-1b76-4a9e-bf79-c4a4d39ec602", "AQAAAAEAACcQAAAAEOH9EBg7v0FdRSgUVzLYwbCrxrsVJFVP3awVzHhK2yq5YfgWp2tHdui9tLu23okU1w==", "6c73c264-b6ae-4820-be47-fdbe4da2e2f6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "billofentrydate",
                table: "Issuetracking");

            migrationBuilder.DropColumn(
                name: "billofentryno",
                table: "Issuetracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e1cedf8-a0be-4888-95a2-05772d7b4116", "AQAAAAEAACcQAAAAEO71CODd8iViqsKg6cqFJgZSrhylzRhBq6Xx0BEZv6AKqDPUkBrGc/4/EN9H+CdJfw==", "0a7c5e5b-bce2-4c5b-958e-7fc8b09a9719" });
        }
    }
}
