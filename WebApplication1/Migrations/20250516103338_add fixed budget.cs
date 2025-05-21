using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addfixedbudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac03c6a-062b-4818-bd2a-ea5f16cc4a1c", "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "FIXEDBUDGETROLE", "FIXEDBUDGETROLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0885aeb6-75b2-46e8-ba8c-5c76388841cc", "AQAAAAEAACcQAAAAEEdrQNACl8TdMirWM1QExocQ64NM3olLkXk2fQLtwzaiQjRQKHqzFxzd06nmCFNePw==", "2576b20f-d7f7-4384-8456-ae5727ad5177" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ac03c6a-062b-4818-bd2a-ea5f16cc4a1c", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ac03c6a-062b-4818-bd2a-ea5f16cc4a1c", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac03c6a-062b-4818-bd2a-ea5f16cc4a1c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc5ff47-b598-4e00-bcc5-6f5fe11b6dbf", "AQAAAAEAACcQAAAAEOIyOci5XyC0ozjlxtwiJfHzN9VHD08DTcn4Tg8B3htRWz08Wwdxl1Szdpfm8lFkSQ==", "562d01c1-d97f-4b46-a304-529d7c2351df" });
        }
    }
}
