using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addxnvnds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "chequedate",
                table: "ReceiptVoucher",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b70dd617-29a2-434e-a601-b881a265a31b", "AQAAAAEAACcQAAAAEGe7ymDZS4zK5J+0c7hACotScrq4R7a7cgS2p88FP3SxoA/QHuPotV45+PhvNgJXRA==", "e8cf4ece-2a14-4ce2-b9cc-7bab4eebb3f9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "chequedate",
                table: "ReceiptVoucher",
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
                values: new object[] { "215c019a-2a73-46f7-bbee-3d17b80d22d3", "AQAAAAEAACcQAAAAEJmkpf+ZWaGqfscX3uWF2Hy5JUTqiRaHNuHv9U8CSsQQAzjYeF+JR1hTBHjvJIhcRA==", "dff0f2cb-17f0-4a70-8482-8e1f9c4c7f08" });
        }
    }
}
