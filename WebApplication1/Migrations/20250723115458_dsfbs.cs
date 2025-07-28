using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dsfbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e83b48f2-1d0f-431a-8da1-6337c608dde3", "AQAAAAEAACcQAAAAEHyor9M5A5VWV2AzyJzULOL9phwOkampHJAN9uPIvZ/qJ6mT2gDYYbmDwwvzCZ/4zg==", "eab68dcf-b5d5-4d32-87b1-4c042aa17c6f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ed4972b-b974-4b30-bf3c-c087adf2b656", "AQAAAAEAACcQAAAAEAVZeMnooYg19uSKf0owzDrsLe5HX07DaEIPm5+suQ5Hcj4frixNX64Ri4YMTj2t/g==", "b8ae7fea-eb67-4c95-83ff-6f7670a67d0a" });
        }
    }
}
