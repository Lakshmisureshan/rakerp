using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addrev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bomjobrevno3",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bomjobstatusid3",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "578fc4bd-d74a-4cf9-bb47-09d7cb1c79ea", "AQAAAAEAACcQAAAAECVT4K7V61C28ZvMHSUsKmYdRjl0RPoafv3rtQ+hYzBwsr7WGgUtzkvsxuHBlek7GQ==", "4c34c82a-d80e-48d6-8455-e2cb1db8456f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bomjobrevno3",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "bomjobstatusid3",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "473bf673-aad3-4cc1-b170-bd2891cfc983", "AQAAAAEAACcQAAAAEMspJMYu1gqMmXAqbk1+1a34d9TA9dsBkPvQDjOnhWHZ/rbJV4uAuiTxW2R0Bw1CVQ==", "63fb3eed-a3c4-4c73-9eef-f11a4de489de" });
        }
    }
}
