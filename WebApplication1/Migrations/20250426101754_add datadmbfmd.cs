using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatadmbfmd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "revision",
                table: "estimation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9a10877-a96b-4417-aa83-874c4846fcaf", "AQAAAAEAACcQAAAAEIU3+f+wNveRY2NEZ8MXsrVHXuVUPIhcjv1ZggZval4KlJcJtQ4Fy5lTaB1avlv6Zg==", "16f1c99c-b9a2-43c8-827c-2012794aeaf6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "revision",
                table: "estimation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56e9f896-56b7-4149-b812-02fba64b4964", "AQAAAAEAACcQAAAAENMJnyXiVz0DNY0uNnMiC8hwyPW4X3xfEK5kFD6587fvwmBRgvyEOVVygj7mLocJhQ==", "b87e499c-44ad-4c50-a780-2d8e1e18603b" });
        }
    }
}
