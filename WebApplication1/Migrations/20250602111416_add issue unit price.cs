using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissueunitprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "issueunitprice",
                table: "Issuenotedetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c4833e8-4fba-48d7-8d2b-f2335c1a8976", "AQAAAAEAACcQAAAAEBIAte7eCzEe/P9/w+tjEZCR3DoGzcBBM/v/MPQHQuoTZ/3Vi2mrgTk3/unAIvSCng==", "f1e0ef8b-39ee-4f55-82a9-7ac95e96db2c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "issueunitprice",
                table: "Issuenotedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f192bd9e-01c6-4eee-b99a-4736032097e1", "AQAAAAEAACcQAAAAEJrdAGdS8Rw/aPuMU8ooWUM1eLmazGNVMFeaOAUt7PIKAf/L2qTPAe54vVxBrs3hfQ==", "5263bdf1-5c4f-46cb-8a95-89cffc6fdf3d" });
        }
    }
}
