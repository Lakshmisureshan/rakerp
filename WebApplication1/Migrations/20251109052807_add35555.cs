using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class add35555 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9c7e3b1-4d0a-4a2e-8b5c-d6f8a3c9e0d2", "f9c7e3b1-4d0a-4a2e-8b5c-d6f8a3c9e0d2", "ENQUIRYCOMPLETED", "ENQUIRYCOMPLETED" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b913c11-195f-4a99-a24c-bb88e939ee3e", "AQAAAAEAACcQAAAAEHI8lbQxWeVIat7E47DisFHRVwYAkHeCGWbZPCZHj4RwoeTUqna8M4h7fJazKzSnKA==", "f5e4f22a-34ab-401e-a2aa-0b2c8fddb05f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9c7e3b1-4d0a-4a2e-8b5c-d6f8a3c9e0d2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5de5a5d6-efd1-46f0-a69a-9a559cde4e82", "AQAAAAEAACcQAAAAELlC02Cp3WeyCsC3oUWIVaNMEwqOcJe3G9ZmVDGPZeT+HrpoPHFFC59TmVi7pY6Iug==", "4ac54746-540c-480d-a7ab-5bcd8aa80a57" });
        }
    }
}
