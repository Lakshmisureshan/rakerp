using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class nsdfnsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8bdf15a1-6234-4e48-843b-14bde44f3dd9", "AQAAAAEAACcQAAAAEFgSb6XlU6Dh/4P+dkNYqWFtBWrJWRsmqxaz/UzWvLy+qcbBoa7rrRZE7gWgHsD2IQ==", "cd56c855-35dc-44d3-8a7a-8b4f80c99008" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f875df60-5de2-4b89-9ecd-e0b965088603", "AQAAAAEAACcQAAAAEAdUBlyl6onjVs55oAdvcE+aRYBMEQuYS16UT6tOB4ghAqNswZZ3eJHj/+LX7d5/Mw==", "cb8b7aa3-9111-41ab-8080-99a3afddc56a" });
        }
    }
}
