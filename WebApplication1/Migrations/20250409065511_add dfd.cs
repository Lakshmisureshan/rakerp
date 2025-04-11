using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d4702f6-25fe-48cd-ab1b-052150bfc5e7", "AQAAAAEAACcQAAAAEObDujfu4oiPPL7K+GzOhvGd3TynIl5w6VbE4ozRaa9R4z8D9uHVJQOMov9WHJ+GiQ==", "1622f60a-bfb4-439d-b816-fd920178f4f9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65692183-dba6-4158-a91d-e6bb103bb9a5", "AQAAAAEAACcQAAAAEDRiZFP8N9Gyij9gF9YAgD9RxDMb/zE8du1du4nnXNvYm964DFYvCb/J95Cr6JHbFQ==", "789e54a7-8808-43ef-8d2b-837dc2139caa" });
        }
    }
}
