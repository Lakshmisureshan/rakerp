using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PR",
                columns: table => new
                {
                    PRID = table.Column<int>(type: "int", nullable: false),
                    Prdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PR", x => x.PRID);
                    table.ForeignKey(
                        name: "FK_PR_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30ad8a34-f89b-4a17-b590-b9ea10973a76", "AQAAAAEAACcQAAAAEIeeRjzz4lz7djYGP0QyH+UH30kDf5bm3jDJofp6hqfQLMXKWX8fSlImpgjrIN3XPg==", "aeb28c49-0a17-4c0f-979d-4bf1da26779b" });

            migrationBuilder.CreateIndex(
                name: "IX_PR_jobid",
                table: "PR",
                column: "jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PR");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f2eaa13-9f0d-4ee6-9a02-89ba3c19a265", "AQAAAAEAACcQAAAAEJ00bl3++9Z7XH6vIOa2A94/aRe9zbKVQJ3ft8KBMP2ra+paXWHgP7eNjtqjjyodPw==", "354504d4-0524-4774-b8ba-57fc88903431" });
        }
    }
}
