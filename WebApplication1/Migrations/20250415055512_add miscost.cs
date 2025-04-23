using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmiscost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Miscost",
                columns: table => new
                {
                    misid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscost", x => x.misid);
                    table.ForeignKey(
                        name: "FK_Miscost_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10606da4-fbb7-4c83-ba8a-5dad88974f02", "AQAAAAEAACcQAAAAEIqTz5Su9qb4ABIC7qiZ4c+QGbdde7dGMhQ9tEpghD1pibHBnYKVPmWoqBnPLHlMNw==", "559d5050-6aad-41d9-ae83-108b2de8c138" });

            migrationBuilder.CreateIndex(
                name: "IX_Miscost_jobid",
                table: "Miscost",
                column: "jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Miscost");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39851c8e-a02b-45f2-8c25-9dec959c917c", "AQAAAAEAACcQAAAAEChj5J2tGSQdVYNyFPWgYVjAj4xBmQ1BFl7xRGbCFsnuAA7hmTQuBT74olC+9PUrJA==", "14f7668c-81bf-459e-95c6-717002fa58e4" });
        }
    }
}
