using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addunfreezeroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b9c2d1e-4a6f-3c8b-2e4d-6a1f8c3b5d7e", "5b9c2d1e-4a6f-3c8b-2e4d-6a1f8c3b5d7e", "JOB UNFREEZE ROLE", "JOB UNFREEZE ROLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6831bc78-9f86-4949-9d27-dd73475cc307", "AQAAAAEAACcQAAAAEC38e4uo5Vs+YDFm2R9f1Kj3LGhLV2nCe8snvZvYaW60ZoSNKCze4Nk6D0DCQ3anRg==", "7c7682ea-9b81-4b9b-ab97-3f2ebb3a1e82" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5b9c2d1e-4a6f-3c8b-2e4d-6a1f8c3b5d7e", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5b9c2d1e-4a6f-3c8b-2e4d-6a1f8c3b5d7e", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9c2d1e-4a6f-3c8b-2e4d-6a1f8c3b5d7e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61681512-1074-426f-822e-703396829b87", "AQAAAAEAACcQAAAAEPgOJYNMFVHZ0IlDMGNFHYJAZHU/P6pIxxZXWB3Lw2PrwBf5GU6+5oCeyFOAQZOivw==", "fef7dd08-1bdb-4e2e-8111-ae87f4c7a002" });
        }
    }
}
