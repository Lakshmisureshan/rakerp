using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuereturnunitprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "irunitprice",
                table: "Issuereturndetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb066f7a-f148-49ab-beef-d64ec5a84d5c", "AQAAAAEAACcQAAAAEFa5I/+2P+VjLtPmOu9SiezMurr6l8kFj8N44YhfLwByz8YkgYkOEs5oes2r/GJllg==", "cc137cac-c2e0-48c0-af37-409913cf9ae8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "irunitprice",
                table: "Issuereturndetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d7c8a24-bb78-4c7e-bb20-b6e6f30c0f15", "AQAAAAEAACcQAAAAEOo91gRlVG5IjeGkRvRsNus9dc2yXJPo9skB1yBeXwy8ThzUuEWV8xfIN+xr+4H/Rg==", "3943bf47-528a-4e62-8385-98098ee82e75" });
        }
    }
}
