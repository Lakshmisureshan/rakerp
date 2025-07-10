using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class hhll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e172e91-eaf0-40f3-8700-6136e38f7908", "AQAAAAEAACcQAAAAELWFnTYUm4WBNCVb3b2GutVw8XNPSyG5oSu3LmnCPQILrWXiYzAIFvj0FeuJ/X6reQ==", "e81b39da-00eb-49b0-be17-05b7d8fd2243" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3a6877e-3352-44f9-b506-e3a640dd6fa9", "AQAAAAEAACcQAAAAEEIXOf4O/zH4U45pKvyAc47PFfZoTlVoD3UcjATt5Gl7a03Nbkj0m691OrwZ0sEuyw==", "ac912541-f219-4849-a703-8be62136ba17" });
        }
    }
}
