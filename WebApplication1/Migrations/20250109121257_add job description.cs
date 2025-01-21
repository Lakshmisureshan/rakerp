using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addjobdescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "jobdescription",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9c1369d-264e-45e9-b0bc-3a06e7c15be9", "AQAAAAEAACcQAAAAEAWB0cQn7ImoamzHL+00fFkxtzMisI7SB53TYsL0Yj0+V/77RgE2rNIsSbVgR0vfvg==", "37d26fff-ab18-4855-9d28-7ac4c9da96ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jobdescription",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c4aa404-822c-4070-aa05-8e89c4a8693a", "AQAAAAEAACcQAAAAEBJPlRLd8FSMVSFPGqgTODRCEJ8Wm0jWMMqd/godaBOeRCvoGNd4Dyuw+AV0nUTBdQ==", "690a34b8-45d7-47a7-85dc-026c7766e6fa" });
        }
    }
}
