using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmanhour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manhour",
                columns: table => new
                {
                    mid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    empid = table.Column<int>(type: "int", nullable: false),
                    jobdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nh = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ot = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    site = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manhour", x => x.mid);
                    table.ForeignKey(
                        name: "FK_manhour_Employeemaster_empid",
                        column: x => x.empid,
                        principalTable: "Employeemaster",
                        principalColumn: "empid");
                    table.ForeignKey(
                        name: "FK_manhour_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c09c51c5-1e9b-4325-8c09-6eeb2b740b74", "AQAAAAEAACcQAAAAEBw3RsDS6UoZPaWBexIXzwZFNHIpSCebYW0f9U+pMgF6LbcBmxMI3exr9kgFD4YFDA==", "a7b96040-1dce-45f7-bf26-e81bc8d5b838" });

            migrationBuilder.CreateIndex(
                name: "IX_manhour_empid",
                table: "manhour",
                column: "empid");

            migrationBuilder.CreateIndex(
                name: "IX_manhour_jobid",
                table: "manhour",
                column: "jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manhour");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d587ed56-3278-47d6-abfc-dccbf27965da", "AQAAAAEAACcQAAAAECST5H2UTf1zfymEuBqUz4ntflywdjUtqr5wHc83/aPgpwroB2CiR+tUagak9lR2OQ==", "92b06ec3-2e12-4aa8-a86f-80d91f8daed7" });
        }
    }
}
