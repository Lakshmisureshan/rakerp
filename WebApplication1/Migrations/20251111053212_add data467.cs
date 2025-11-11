using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddata467 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7a2f5d1e-8b3c-4e6a-9d0b-2c4f7a1e3b5d", "7a2f5d1e-8b3c-4e6a-9d0b-2c4f7a1e3b5d", "ENQUIRYVERIFIED", "ENQUIRYVERIFIED" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2df008a5-9700-40ef-845f-da6ebc72f22f", "AQAAAAEAACcQAAAAEJCRyLiGtgDKuLksAysxM6qs9V86WRCucpjkrTlcw9aD8Cwrrj8E5QL5CwDHRmCBzw==", "71beadc9-8c95-46b0-8209-51f47eba2a0d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a2f5d1e-8b3c-4e6a-9d0b-2c4f7a1e3b5d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b913c11-195f-4a99-a24c-bb88e939ee3e", "AQAAAAEAACcQAAAAEHI8lbQxWeVIat7E47DisFHRVwYAkHeCGWbZPCZHj4RwoeTUqna8M4h7fJazKzSnKA==", "f5e4f22a-34ab-401e-a2aa-0b2c8fddb05f" });
        }
    }
}
