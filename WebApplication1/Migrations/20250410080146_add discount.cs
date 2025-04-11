using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                table: "PO",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fd8ded8-f514-4260-bb6a-0adfa3fdcf54", "AQAAAAEAACcQAAAAENHdpI4S6Am2ZY3qkza+Q7J9d6Z2UwVlT/iT276f0GPH/s0Xb7DOPY5SRcaURJus3Q==", "a74c8e29-83d4-4316-b239-7efc6d21a792" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discount",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a12ffcab-924b-4969-b84e-4f9847c6e87f", "AQAAAAEAACcQAAAAECwy1mVi1wPbclvnU5IzcnlIljbRYAScwkOQl887l10f2ekwQJn2CAUa/xKMFGJN6Q==", "cff86d59-cdd0-42df-ad45-cf22d21a27ca" });
        }
    }
}
