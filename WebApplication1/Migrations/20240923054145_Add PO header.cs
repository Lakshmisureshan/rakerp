using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddPOheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PO",
                columns: table => new
                {
                    Orderid = table.Column<int>(type: "int", nullable: false),
                    Podate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdbyid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    modifiedbyid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    poverifiedbyid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PoAuthorizedbyid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PO", x => x.Orderid);
                    table.ForeignKey(
                        name: "FK_PO_AspNetUsers_createdbyid",
                        column: x => x.createdbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PO_AspNetUsers_modifiedbyid",
                        column: x => x.modifiedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PO_AspNetUsers_PoAuthorizedbyid",
                        column: x => x.PoAuthorizedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PO_AspNetUsers_poverifiedbyid",
                        column: x => x.poverifiedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PO_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97a88d18-1780-4c8a-8561-14d76060e39f", "AQAAAAEAACcQAAAAEISSjVclv3oT5MJdjMrOlrqvrfqe8gkl21uXJR7pW6/ovphXb/dqGyQwz5cgQSTjpg==", "576d26fa-0b35-4f08-a288-651c79991641" });

            migrationBuilder.CreateIndex(
                name: "IX_PO_createdbyid",
                table: "PO",
                column: "createdbyid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_jobid",
                table: "PO",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_modifiedbyid",
                table: "PO",
                column: "modifiedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_PoAuthorizedbyid",
                table: "PO",
                column: "PoAuthorizedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_poverifiedbyid",
                table: "PO",
                column: "poverifiedbyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54998d36-42a7-4d84-bd4d-306e86ef93b9", "AQAAAAEAACcQAAAAEF6Dfo5mWA+rDdrN8hgu9AqYDZD1Gon8TsoPJ52Sen0biKesTaQRvWih+26Y49p4tw==", "d43b14ed-8847-48d8-8795-d6a299ba3e54" });
        }
    }
}
