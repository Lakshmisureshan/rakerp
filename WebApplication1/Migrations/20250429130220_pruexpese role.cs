using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class pruexpeserole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "553d0b9b-15cf-4879-8ac9-e42e13e35e22", "553d0b9b-15cf-4879-8ac9-e42e13e35e22", "PRUEXPENSEROLE", "PRUEXPENSEROLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a916d50-c864-44a0-8e76-6092674715d3", "AQAAAAEAACcQAAAAEOqYHOUulyajs1rQFisOGzza66i6XUTG7pGzdeTFoM10WJdPSaA2RjvrwiLZA3haUA==", "e8cacf0e-dd58-4bf6-8af1-e4814cfe9d8d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "553d0b9b-15cf-4879-8ac9-e42e13e35e22", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "553d0b9b-15cf-4879-8ac9-e42e13e35e22", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "553d0b9b-15cf-4879-8ac9-e42e13e35e22");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57093d17-983b-4d5c-bc20-edb86591b434", "AQAAAAEAACcQAAAAECFsaKAax1TOhkRNVhPF8WTHGUlCLnIPrth3gqlBex2aPH4Swj63nZL0kkKiHy7W8w==", "0113782b-8cc0-4d3a-8941-9622df5a6d85" });
        }
    }
}
