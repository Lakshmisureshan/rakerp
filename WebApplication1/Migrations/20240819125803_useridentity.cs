using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class useridentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c8cdf22-752c-446a-bb42-9bea05872bd5", "3c8cdf22-752c-446a-bb42-9bea05872bd5", "TradeManager", "TRADEMANAGER" },
                    { "72c35b91-4022-4c2b-adc3-1ec004c08a21", "72c35b91-4022-4c2b-adc3-1ec004c08a21", "FinanceManager", "FINANCEMANAGER" },
                    { "9ab357a2-67a2-4be8-82fd-12339553dd8b", "9ab357a2-67a2-4be8-82fd-12339553dd8b", "Writer", "WRITER" },
                    { "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "TradeUser", "TRADEUSER" },
                    { "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "356ff228-0e5f-436a-9ac5-2d760b997dd5", 0, "328bc4e0-ed1f-45d9-9b16-d90b66e11c7d", "admin@trading.com", false, false, null, "ADMIN@TRADING.COM", "ADMIN@TRADING.COM", "AQAAAAEAACcQAAAAEF+FHRfNQ2YGLmipdfC75nJLE00WSc9ylChOjpvHCBlH8IHvT4zIZjGz7PxmEd221g==", null, false, "289b9f06-fdb6-400d-acec-866662cf4e8b", false, "admin@trading.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3c8cdf22-752c-446a-bb42-9bea05872bd5", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "72c35b91-4022-4c2b-adc3-1ec004c08a21", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "9ab357a2-67a2-4be8-82fd-12339553dd8b", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "356ff228-0e5f-436a-9ac5-2d760b997dd5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3c8cdf22-752c-446a-bb42-9bea05872bd5", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "72c35b91-4022-4c2b-adc3-1ec004c08a21", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ab357a2-67a2-4be8-82fd-12339553dd8b", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c8cdf22-752c-446a-bb42-9bea05872bd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72c35b91-4022-4c2b-adc3-1ec004c08a21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ab357a2-67a2-4be8-82fd-12339553dd8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b52de381-7ff6-4d7f-a385-51fa28f43aaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e76b0657-67f3-4e84-9320-1ed68a80a8f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5");
        }
    }
}
