using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class PRverification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad", "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad", "PRVerification", "PRVERIFICATION" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8c03e95-4f40-439e-8f1a-d61fc3bb2be2", "AQAAAAEAACcQAAAAEA6QcRjyLOur0yQ2NZ9zqFXVqTcZvgl8zLnb8Car7lEhhEbuwAK+exwjPN5gXWswLw==", "aa30ace0-ff8c-4005-9699-e0cd853246b6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec09b2af-79ca-4ef4-b8af-de8f7966d011", "AQAAAAEAACcQAAAAEDH6GtkSR8D1/uBM6QEJy61w3R5cxPfxipMhfJhKz753nM23WqmjUwnBn9oZMi3KMQ==", "b98325cb-306f-4f4f-a2e3-a0235851fdaa" });
        }
    }
}
