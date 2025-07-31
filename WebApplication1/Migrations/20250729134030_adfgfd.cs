using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adfgfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d1bad9a-057c-4c32-ad91-ef4d10b158aa", "7d1bad9a-057c-4c32-ad91-ef4d10b158aa", "RECEIVEDENTRYREGISTRATIONROLE", "RECEIVEDENTRYREGISTRATIONROLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5a1fa74-e04c-42dc-9aa5-ebd253ab82bb", "AQAAAAEAACcQAAAAEEX86wljgyMQIBJ4sMDs6k397a8dTrpWF8ElW24cLDfl2wYC/63eHkefA/NtG4F2jQ==", "c466c479-ff19-4c9a-944a-9084069fd79c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d1bad9a-057c-4c32-ad91-ef4d10b158aa", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d1bad9a-057c-4c32-ad91-ef4d10b158aa", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d1bad9a-057c-4c32-ad91-ef4d10b158aa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5e30244-aeb5-4872-a809-3d710e6790f7", "AQAAAAEAACcQAAAAEMCtZ1HqYpwPmwliL9q/FjCaF4GaxCyQzZ/KJ35FMGeh4ColJ6VpANSJCAZ1V/rrBg==", "690e5f55-620b-49e1-8060-c35b50d795d6" });
        }
    }
}
