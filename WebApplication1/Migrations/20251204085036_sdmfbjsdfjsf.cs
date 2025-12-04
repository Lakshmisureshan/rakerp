using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class sdmfbjsdfjsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2e8c4f1-3b6d-4e90-b1c7-5f2a9d8c0b3e", "a2e8c4f1-3b6d-4e90-b1c7-5f2a9d8c0b3e", "JOB FREEZE ROLE", "JOB FREEZE ROLE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0fbd763d-ec2c-42d0-9c4b-229f9444f7b1", "AQAAAAEAACcQAAAAEFV2iMS+DLzW8SDCjVgI5jh6FYBWQTgd7axdyhKWciAI1caH444CxJ/lmhzH/i+bxw==", "9d1eb4a7-ba7c-4af4-b7e1-3b093a31a428" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a2e8c4f1-3b6d-4e90-b1c7-5f2a9d8c0b3e", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a2e8c4f1-3b6d-4e90-b1c7-5f2a9d8c0b3e", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2e8c4f1-3b6d-4e90-b1c7-5f2a9d8c0b3e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "620ccbfe-2d78-4522-be03-5b19dbdee7cd", "AQAAAAEAACcQAAAAEGnl4YkXFA6lGSNkoaqMaQiuggYHgJi6m3l1j5bfmtlNW8lWtDwlhqlgo//NlpEweQ==", "4ca5dd8d-a729-4837-8eea-a21018917d67" });
        }
    }
}
