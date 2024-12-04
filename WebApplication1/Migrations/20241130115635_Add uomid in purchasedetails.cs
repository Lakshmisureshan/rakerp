using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Adduomidinpurchasedetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f5cb969-30d1-4ee7-8141-dca08aa8e934", "AQAAAAEAACcQAAAAEGvSWf8dy1jrwkKL2xBzw4NUJ5sguKT5DeaGhavn8RP9Ly2wJC5xYKSNqyz6DD3/bw==", "b0a69ed1-67fa-4d74-8b7b-9b17ebfa53ff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebfc8815-d458-4592-a4a3-5e205ace9558", "AQAAAAEAACcQAAAAEOSLD8qCwafMODsVUWvzW1kU1PjNMtGyqmCqH6sLUz6sbQKu4FGZVdr7UoptZkSN5w==", "c78090d9-8aec-47a3-b60d-b5fa44f4376a" });
        }
    }
}
