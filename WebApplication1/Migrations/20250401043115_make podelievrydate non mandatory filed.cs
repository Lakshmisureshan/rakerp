using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class makepodelievrydatenonmandatoryfiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "podeliverydate",
                table: "Job",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56ded367-124b-4080-a136-681d5db1f20f", "AQAAAAEAACcQAAAAEJyxW3UTiJcv1ORWzWMyV6nNjkvnD9fQRAvH/WnfXbewm5tF7SOq15kgq++1NCyY5g==", "c126a095-6e68-4070-9f01-5d02b1256217" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "podeliverydate",
                table: "Job",
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
                values: new object[] { "e967adb0-f2b7-4e7e-b6c6-760a3c3c9995", "AQAAAAEAACcQAAAAEMcp9qW10Uual4II+anRwyKk6bXlUKYa/Wqq0s/lnZkt8edcJwOGkdP1CEpAOuIX8g==", "3ff2e913-5bfe-4191-a549-e5a33ee01509" });
        }
    }
}
