using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "Company",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46fbc0b8-8995-4697-ac4f-196cec66f0a5", "AQAAAAEAACcQAAAAEI8q3bWTDPhVOoWSHnA73Z9fOzVclLw4D9ib+VDorZyjKyzj/fJvAo6o9hYi2TJgSA==", "2da60a7c-8c30-48e0-bce4-41b32c125727" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createddate",
                table: "Company");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa4ea7d7-e0b2-4997-8109-0eec21c3927f", "AQAAAAEAACcQAAAAEG+ce2M3f4VSdvuBnBiyrd2tVwIdvPN3D1qj9ZYUfda7vAGan9DiFXtOBTN4Q6B+qw==", "e154e7da-9b2d-49bc-8a60-9d9967dd2441" });
        }
    }
}
