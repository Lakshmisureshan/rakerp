using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addmainjobid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "mainjobid",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53652192-b514-4188-b2fd-246b8359bc67", "AQAAAAEAACcQAAAAEJsks3jnsrTNmU59hM4MBdyvOn5Z+ymYQ8rYYslWSFeDttaA5YsT6I0NcTSaawZYWg==", "3a4d3d2c-6600-4069-b4ad-447bee6a9bd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mainjobid",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9986e2b2-7fad-4574-8c19-cf617c0babe3", "AQAAAAEAACcQAAAAEFbbkJ0cqWq8TJ2nG4kr6Hjr11ZJ5OFooPcmvougzaRd7Vx2pbqnvSjS+ylZnehEaA==", "9cfbe7d4-79a1-46ba-bf63-86d220d706a4" });
        }
    }
}
