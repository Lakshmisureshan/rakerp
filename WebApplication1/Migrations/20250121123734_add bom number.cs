using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addbomnumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bomnumber",
                table: "Bom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0b65614-5338-4d4f-b5df-c18e14301916", "AQAAAAEAACcQAAAAEG0mnusH9JL6hewfv9ML2OfjvofQZdQkW7Fe9lv+w02ObUgUaoXQd3SXjbku7Q8bnw==", "3cf3c76f-d0d6-453c-9ef8-a14504d0b2af" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bomnumber",
                table: "Bom");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f770bf2b-824e-4ca3-afa0-f5177712e132", "AQAAAAEAACcQAAAAENIwecoJODV/2ieoYUvWXeQvXafH9/AyB7TQ47F/6jpLkTujUZu+3L9zaOeXjyLCuA==", "8860bd9f-deb6-4944-973d-41ca078bd726" });
        }
    }
}
