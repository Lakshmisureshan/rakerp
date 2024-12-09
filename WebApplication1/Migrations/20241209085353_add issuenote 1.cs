using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuenote1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueNoteheader",
                columns: table => new
                {
                    issueref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issuedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueNoteheader", x => x.issueref);
                    table.ForeignKey(
                        name: "FK_IssueNoteheader_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab9176f6-4c73-4fec-a663-ba7b4e5b71b4", "AQAAAAEAACcQAAAAEKSXuoYJgURVq5aspwN2L5vonYO/0Qvsyp4uB1zdDYGbtyysIqxskZzHtHHAQYAOBA==", "e95ab56e-b3a5-4972-bc5d-d9a1bf75fc01" });

            migrationBuilder.CreateIndex(
                name: "IX_IssueNoteheader_jobid",
                table: "IssueNoteheader",
                column: "jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueNoteheader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fb31ac8-ba84-4cc4-ae54-6a0a59df9d5a", "AQAAAAEAACcQAAAAEDkEviMur4weBF80zubxswvcizN6LhefIiXR2SnUWkyzU5CwpcAo1zv04bUh/J/Azg==", "2c78f0ed-ee85-4032-821d-e39f8cb16291" });
        }
    }
}
