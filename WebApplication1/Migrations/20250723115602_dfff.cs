using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dfff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9828ce7b-34da-4689-a2c7-b5d9d2522156", "AQAAAAEAACcQAAAAEDfIUXapXG2i0yh5UuKcyjtxVo6ul0znQwIZg6rDr7S9vBAkxj6L3oYJ31yyPv+Rwg==", "893839d2-f7e9-47e5-afaa-02939bae7a41" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e83b48f2-1d0f-431a-8da1-6337c608dde3", "AQAAAAEAACcQAAAAEHyor9M5A5VWV2AzyJzULOL9phwOkampHJAN9uPIvZ/qJ6mT2gDYYbmDwwvzCZ/4zg==", "eab68dcf-b5d5-4d32-87b1-4c042aa17c6f" });
        }
    }
}
