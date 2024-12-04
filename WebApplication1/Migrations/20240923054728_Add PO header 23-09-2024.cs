using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddPOheader23092024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "poverifiedbyid",
                table: "PO",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "modifiedbyid",
                table: "PO",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PoAuthorizedbyid",
                table: "PO",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<DateTime>(
                name: "poauthorizedDate",
                table: "PO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "poverifiedDate",
                table: "PO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce5be5b5-7407-4e5e-b2b8-c555538e85b4", "AQAAAAEAACcQAAAAEOJGBn6pcHx4BbSY7TwjSZCP8KhDw9Y70HZMXexmk1xmE+yRerkr4KMPEbP6157TGQ==", "3b444c44-ea6f-49f2-97b1-7f37de1006fd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "poauthorizedDate",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "poverifiedDate",
                table: "PO");

            migrationBuilder.AlterColumn<string>(
                name: "poverifiedbyid",
                table: "PO",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "modifiedbyid",
                table: "PO",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PoAuthorizedbyid",
                table: "PO",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97a88d18-1780-4c8a-8561-14d76060e39f", "AQAAAAEAACcQAAAAEISSjVclv3oT5MJdjMrOlrqvrfqe8gkl21uXJR7pW6/ovphXb/dqGyQwz5cgQSTjpg==", "576d26fa-0b35-4f08-a288-651c79991641" });
        }
    }
}
