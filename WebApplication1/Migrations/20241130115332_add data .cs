using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebfc8815-d458-4592-a4a3-5e205ace9558", "AQAAAAEAACcQAAAAEOSLD8qCwafMODsVUWvzW1kU1PjNMtGyqmCqH6sLUz6sbQKu4FGZVdr7UoptZkSN5w==", "c78090d9-8aec-47a3-b60d-b5fa44f4376a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87fec879-5a20-44cc-9736-e55f0241e3e0", "AQAAAAEAACcQAAAAED1g/yYX7+eemACPLe2NSjhIeZ+rrfkgjfPyuTw/n129JUCnMcGHmWG/oN9Zkx6+MQ==", "9e6605ae-6802-4234-a5b5-a65161979298" });
        }
    }
}
