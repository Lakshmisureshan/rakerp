using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsupplierdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "suppliertrnno",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "Supplier",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "emailaddress",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fax",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phoneno",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "remarks",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "supplierpoboxno",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "webaddress",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df7a3f80-b771-4888-bbbf-e6b90e88b481", "AQAAAAEAACcQAAAAEOeRSkQvSNguMwzdRcc4/XL0reuSX5VBY3C4UkKvBjMSWmp5Bm4kZlzCXlHO/wNqpg==", "b2616bbe-8c24-485d-a51e-4aa3483431f7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createddate",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "emailaddress",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "fax",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "phoneno",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "remarks",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "supplierpoboxno",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "webaddress",
                table: "Supplier");

            migrationBuilder.AlterColumn<string>(
                name: "suppliertrnno",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21ec6bc5-25cf-49f3-bc5a-6d7bfb419fad", "AQAAAAEAACcQAAAAEAkfjMyakWn8HTiVIiWpmhjcMXRJsEySikx7an6UDrOCYm0ZmW9Q7kgp4iTsLL1fGw==", "9340996e-4594-4de9-bf4e-1b1d593849d5" });
        }
    }
}
