using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dfmnbd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f875df60-5de2-4b89-9ecd-e0b965088603", "AQAAAAEAACcQAAAAEAdUBlyl6onjVs55oAdvcE+aRYBMEQuYS16UT6tOB4ghAqNswZZ3eJHj/+LX7d5/Mw==", "cb8b7aa3-9111-41ab-8080-99a3afddc56a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b2c7085-628d-4912-90d9-ef6cdab9b2ee", "AQAAAAEAACcQAAAAEBV2ZmdMLQbL5cWyIFU+UVsssVx4THDjE7HI1c7BwvJSHyA8He9g9o7q5FxwpsLW5w==", "c74b6216-9de1-4899-996b-2a48d21732ab" });
        }
    }
}
