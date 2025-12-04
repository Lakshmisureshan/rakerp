using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class pounauthorizerole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8f3d1c9a-5e2b-4d0f-7a6c-9b4e2a1d0f3c", "8f3d1c9a-5e2b-4d0f-7a6c-9b4e2a1d0f3c", "PO UNAUTHORIZE ROLE", "PO UNAUTHORIZE ROLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25039f36-4288-4288-9dd3-6e4c856fcc63", "AQAAAAEAACcQAAAAEK/vXRCE/aM2r5AlBSW4zZR8jwz8E3Yv9jyXTxDzS1UuIhaLlRyoDgmegImcq5tTiQ==", "f3c3fa43-c8a0-4f40-937e-b5240b911bcd" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8f3d1c9a-5e2b-4d0f-7a6c-9b4e2a1d0f3c", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8f3d1c9a-5e2b-4d0f-7a6c-9b4e2a1d0f3c", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f3d1c9a-5e2b-4d0f-7a6c-9b4e2a1d0f3c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6831bc78-9f86-4949-9d27-dd73475cc307", "AQAAAAEAACcQAAAAEC38e4uo5Vs+YDFm2R9f1Kj3LGhLV2nCe8snvZvYaW60ZoSNKCze4Nk6D0DCQ3anRg==", "7c7682ea-9b81-4b9b-ab97-3f2ebb3a1e82" });
        }
    }
}
