using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsuppliercontactdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "SupplierContact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mobile",
                table: "SupplierContact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phoneno",
                table: "SupplierContact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8fb17b0-fa4c-446f-9b04-220f0d111f5c", "AQAAAAEAACcQAAAAEKLREZIwPeETy8pXFjG+YBN7DqybGCd3+i72kbN7ImnZCBD+VqwUjetsQoOAaFpgNg==", "83a489f6-c1f9-49e8-a48b-5809c1c498ea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "SupplierContact");

            migrationBuilder.DropColumn(
                name: "mobile",
                table: "SupplierContact");

            migrationBuilder.DropColumn(
                name: "phoneno",
                table: "SupplierContact");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcd1c2f9-54cb-4e5d-873f-5d403799aa14", "AQAAAAEAACcQAAAAENPpdMXS0AFakVw/24c/LRzKFwQ5tJv1+l+i+9zMEpoGlZoENMpjbbLBNw2prbyYVQ==", "02c177b2-8fb0-40fa-b436-6f37bc2e6402" });
        }
    }
}
