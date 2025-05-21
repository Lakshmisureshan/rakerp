using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsupplierornot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b2c7085-628d-4912-90d9-ef6cdab9b2ee", "AQAAAAEAACcQAAAAEBV2ZmdMLQbL5cWyIFU+UVsssVx4THDjE7HI1c7BwvJSHyA8He9g9o7q5FxwpsLW5w==", "c74b6216-9de1-4899-996b-2a48d21732ab" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b19a37d7-4541-44b2-be21-593e45f54f81", "AQAAAAEAACcQAAAAEEr+UeemCsprvX/9DYtmpQ6urfyOROw9q/nnZVW3oqy7ogS9lMVOObndpKN+nOkEYg==", "7c6de369-de2c-44dc-9334-ce57291624a6" });
        }
    }
}
