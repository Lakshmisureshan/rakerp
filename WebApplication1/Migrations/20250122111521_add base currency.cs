using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addbasecurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4ca4b91-562f-4733-9e84-85508bca1dfe", "AQAAAAEAACcQAAAAEHvfpODCUloyNIYt/Ik8nY6QgdBfg7D8yuPZXqo8gB45vBI/tmMvkI0yQ7z+r/USZA==", "495f70d1-a59c-4182-a064-91fd703fd950" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0b65614-5338-4d4f-b5df-c18e14301916", "AQAAAAEAACcQAAAAEG0mnusH9JL6hewfv9ML2OfjvofQZdQkW7Fe9lv+w02ObUgUaoXQd3SXjbku7Q8bnw==", "3cf3c76f-d0d6-453c-9ef8-a14504d0b2af" });
        }
    }
}
