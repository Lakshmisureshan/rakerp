using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class bfcgffg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Issuereturn",
                columns: table => new
                {
                    issuereturnref = table.Column<int>(type: "int", nullable: false),
                    returndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuereturn", x => x.issuereturnref);
                    table.ForeignKey(
                        name: "FK_Issuereturn_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b517eb57-c21f-42bc-8bde-11c8c82ce5d1", "AQAAAAEAACcQAAAAEB7Qbs25EEaUieGMjHoCpiVPZ00nW27R5EUBcY6JKLpFeUuUCoTwWSyNkYiUhHm57Q==", "5b421c29-691a-4a23-80ec-77fdea3c738d" });

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturn_jobid",
                table: "Issuereturn",
                column: "jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issuereturn");

          

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a8aa62c-40c8-40fb-b100-2a4a938d7077", "AQAAAAEAACcQAAAAEO5F8aHMjfsmTjZda25S708Rlpm8/NrlWg5Zx6e3+HgID9nRaFZB6MNxseksiT9eLA==", "d549177d-ea81-4a6f-90b0-b64176341bb0" });

           
        }
    }
}
