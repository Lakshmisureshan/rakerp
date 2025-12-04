using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addusercreationrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6a9f0e3-8d2a-4b7c-9e1f-7d4b5a2c1e8d", "c6a9f0e3-8d2a-4b7c-9e1f-7d4b5a2c1e8d", "JOB CREATION ROLE", "JOB CREATION ROLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61681512-1074-426f-822e-703396829b87", "AQAAAAEAACcQAAAAEPgOJYNMFVHZ0IlDMGNFHYJAZHU/P6pIxxZXWB3Lw2PrwBf5GU6+5oCeyFOAQZOivw==", "fef7dd08-1bdb-4e2e-8111-ae87f4c7a002" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c6a9f0e3-8d2a-4b7c-9e1f-7d4b5a2c1e8d", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6a9f0e3-8d2a-4b7c-9e1f-7d4b5a2c1e8d", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6a9f0e3-8d2a-4b7c-9e1f-7d4b5a2c1e8d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fbd763d-ec2c-42d0-9c4b-229f9444f7b1", "AQAAAAEAACcQAAAAEFV2iMS+DLzW8SDCjVgI5jh6FYBWQTgd7axdyhKWciAI1caH444CxJ/lmhzH/i+bxw==", "9d1eb4a7-ba7c-4af4-b7e1-3b093a31a428" });
        }
    }
}
