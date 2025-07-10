using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatadfds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3a6877e-3352-44f9-b506-e3a640dd6fa9", "AQAAAAEAACcQAAAAEEIXOf4O/zH4U45pKvyAc47PFfZoTlVoD3UcjATt5Gl7a03Nbkj0m691OrwZ0sEuyw==", "ac912541-f219-4849-a703-8be62136ba17" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f501deb-58a7-40b3-a345-3b79709a6a4f", "AQAAAAEAACcQAAAAELjZUohzKvX0uLc0awzgwMtl0JW48X6w1W3HIFQ1vzWjqTj279Ioe8gIExLKWP8rNw==", "46968392-8cac-4123-8ecc-f6749bab2597" });
        }
    }
}
