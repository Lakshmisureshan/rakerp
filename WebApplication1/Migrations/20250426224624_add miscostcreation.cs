using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmiscostcreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b65fb755-5a86-46a7-b28d-8e935c05b967", "b65fb755-5a86-46a7-b28d-8e935c05b967", "Miscostcreation", "MISCOSTCREATION" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0170bb4-3824-4248-a168-460d1911f78a", "AQAAAAEAACcQAAAAEPiulZd6dk3jr5p1KrlmBqzdCM0AOBzcTTFVfu7Kf9refsMxzS/q2WDRiVqE6qaVCA==", "9d583ae8-2548-4a62-93fd-fc04bb58433f" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b65fb755-5a86-46a7-b28d-8e935c05b967", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b65fb755-5a86-46a7-b28d-8e935c05b967", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b65fb755-5a86-46a7-b28d-8e935c05b967");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf8d914e-bab5-4e09-8c57-790b68518335", "AQAAAAEAACcQAAAAEO8Kpz1D6wIXYQ3rliMT8TmTF4kOovElSL36XaLCx/N2puRZyJ/qXrNeZU6gAAk1Mw==", "75f46ceb-b29e-480b-909e-da6d1c993481" });
        }
    }
}
