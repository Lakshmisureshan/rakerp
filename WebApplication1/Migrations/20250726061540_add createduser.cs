using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcreateduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdbyuser",
                table: "Miscost",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "Miscost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a73823d2-c342-4956-b3f0-ef7f19947668", "AQAAAAEAACcQAAAAEBtEuhvJYOje1qpYma/GlczfBHemfRQ700qIJv8YnTqi7prQ5rT/yiwJlgZ1oQEyKQ==", "0adde0e4-3679-437d-a22d-f20c964ad066" });

            migrationBuilder.CreateIndex(
                name: "IX_Miscost_createdbyuser",
                table: "Miscost",
                column: "createdbyuser");

            migrationBuilder.AddForeignKey(
                name: "FK_Miscost_AspNetUsers_createdbyuser",
                table: "Miscost",
                column: "createdbyuser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Miscost_AspNetUsers_createdbyuser",
                table: "Miscost");

            migrationBuilder.DropIndex(
                name: "IX_Miscost_createdbyuser",
                table: "Miscost");

            migrationBuilder.DropColumn(
                name: "createdbyuser",
                table: "Miscost");

            migrationBuilder.DropColumn(
                name: "createddate",
                table: "Miscost");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c84beb3e-1821-4e01-a919-b4e80300f22b", "AQAAAAEAACcQAAAAEJoa4k76DJUuEdJsXQWgXBN8lId3hqymGfcG+q0jFt22z+80gEtIZQR8EVotgDtITg==", "8da4358a-7755-49ea-9ea5-622f8ef406a7" });
        }
    }
}
