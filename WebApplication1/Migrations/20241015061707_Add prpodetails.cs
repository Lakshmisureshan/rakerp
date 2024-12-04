using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addprpodetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c56a208-7de9-43b4-878a-97e376488476", "AQAAAAEAACcQAAAAEIPESHjUPSENA6w53KuyDSr16lSU+mUKjcsVl2gxQveMCEtU+9LF5DBlQL+YHfUpAQ==", "6faadb01-fb15-42f2-afe1-0ff6edb5a622" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59cc1171-8988-4ccf-9b79-6bd6cc7fd505", "AQAAAAEAACcQAAAAEDVRLhPSziXawE2xqagZeRa83tD7kHC45+TvM+e0Psr6AurEYidxim2nuxiDk2k1zA==", "223d4b72-1595-40b5-b6ed-a29405022d7c" });
        }
    }
}
