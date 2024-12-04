using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addgrnregistrationrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e05d3da2-24c8-43fb-859f-cdbee6ac2a73", "e05d3da2-24c8-43fb-859f-cdbee6ac2a73", "GRNRegistration", "GRNREGISTRATION" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a77a2b3e-957f-4c27-9c12-57c78e29b86e", "AQAAAAEAACcQAAAAEL8vX7Rw6Qpbw5IwxmR55Ewq9zlJYEiVFqFWM7EC0zQvGopoSt1Jq5FW/hE8bv+XTA==", "2ee5df6e-b5c6-426b-830c-1da5b2c66223" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e05d3da2-24c8-43fb-859f-cdbee6ac2a73", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e05d3da2-24c8-43fb-859f-cdbee6ac2a73", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e05d3da2-24c8-43fb-859f-cdbee6ac2a73");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f5cb969-30d1-4ee7-8141-dca08aa8e934", "AQAAAAEAACcQAAAAEGvSWf8dy1jrwkKL2xBzw4NUJ5sguKT5DeaGhavn8RP9Ly2wJC5xYKSNqyz6DD3/bw==", "b0a69ed1-67fa-4d74-8b7b-9b17ebfa53ff" });
        }
    }
}
