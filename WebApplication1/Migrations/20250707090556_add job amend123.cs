using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addjobamend123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // This section creates the new 'jobamend' table.
            // This is what you want to keep.
            migrationBuilder.CreateTable(
                name: "jobamend", // This is the new table name
                columns: table => new
                {
                    amid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    amenddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amendvalueinbasecurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    amenduserid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobamend", x => x.amid);
                    table.ForeignKey(
                        name: "FK_jobamend_AspNetUsers_amenduserid",
                        column: x => x.amenduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_jobamend_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            // These are related to the new 'jobamend' table's indexes.
            migrationBuilder.CreateIndex(
                name: "IX_jobamend_amenduserid",
                table: "jobamend",
                column: "amenduserid");

            migrationBuilder.CreateIndex(
                name: "IX_jobamend_jobid",
                table: "jobamend",
                column: "jobid");

            // Keep this if it's genuinely part of this migration and intended
            // to update existing user data regardless of the table creation.
            // If it's unrelated, consider if it belongs in a separate migration.
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7062c990-561a-4e6b-b6f2-b6d1f3c5324b", "AQAAAAEAACcQAAAAEG5S12Ns3SOBxLoNqkv6z5eVuK4cN0C5zRu8GoaweR2Peuxe3EUEpxctCN9lvN841g==", "6bd3d8f2-6660-4d39-94f0-647b8b91ba79" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // This section should ONLY undo what was done in the Up method of THIS migration.
            // So, it should only drop the 'jobamend' table.

            migrationBuilder.DropTable(
                name: "jobamend"); // Drop the new table created in Up()

            // REMOVE ALL THE FOLLOWING LINES THAT REFER TO 'jobamendment'
            // AS YOU STATED YOU WANT TO "forget about jobamendment table".
            /*
            migrationBuilder.CreateTable(
                name: "jobamendment",
                columns: table => new
                {
                    amid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amenduserid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    amenddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    amendvalueinbasecurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobamendment", x => x.amid);
                    table.ForeignKey(
                        name: "FK_jobamendment_AspNetUsers_amenduserid",
                        column: x => x.amenduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_jobamendment_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            // This UpdateData is for AspNetUsers, keep it if it's meant to be here
            // (though it's unusual to have it in both Up and Down unless it's for a very specific reason).
            // For a simple table creation/deletion migration, it's usually not present in Down.
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a95afc34-5737-4946-b146-b6bf9a727e06", "AQAAAAEAACcQAAAAEEbDSeimrT33wbyazH5/0v7vPtownLLY9DBS6+DEbSXa2dxszAlP56U4bzH9Gp/0YA==", "fe1b2d42-319b-4b99-b9ee-5b3674d93a28" });

            migrationBuilder.CreateIndex(
                name: "IX_jobamendment_amenduserid",
                table: "jobamendment",
                column: "amenduserid");

            migrationBuilder.CreateIndex(
                name: "IX_jobamendment_jobid",
                table: "jobamendment",
                table: "jobamendment",
                column: "jobid");
            */
        }
    }
}