using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addjobtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Jobid = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    jobtypeid = table.Column<int>(type: "int", nullable: false),
                    jobdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lpodate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lpono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectmanagerid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    projectengineerid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    totalnumber = table.Column<int>(type: "int", nullable: false),
                    manufacturingbayid = table.Column<int>(type: "int", nullable: false),
                    qualitylevelid = table.Column<int>(type: "int", nullable: false),
                    podeliverydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectcategoryid = table.Column<int>(type: "int", nullable: false),
                    isldapplicable = table.Column<int>(type: "int", nullable: false),
                    ldpercent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currencyid = table.Column<int>(type: "int", nullable: false),
                    exchangerate = table.Column<double>(type: "float", nullable: false),
                    ordervalue = table.Column<double>(type: "float", nullable: false),
                    ordervaluebasecurrency = table.Column<double>(type: "float", nullable: false),
                    projectname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentterms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    warrantyterms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deliveryterms = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Jobid);
                    table.ForeignKey(
                        name: "FK_Job_AspNetUsers_projectengineerid",
                        column: x => x.projectengineerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Job_AspNetUsers_projectmanagerid",
                        column: x => x.projectmanagerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Job_Currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Job_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_IsLDApplicable_isldapplicable",
                        column: x => x.isldapplicable,
                        principalTable: "IsLDApplicable",
                        principalColumn: "ldid");
                    table.ForeignKey(
                        name: "FK_Job_JobType_jobtypeid",
                        column: x => x.jobtypeid,
                        principalTable: "JobType",
                        principalColumn: "jobtypeid");
                    table.ForeignKey(
                        name: "FK_Job_ManufacturingBay_manufacturingbayid",
                        column: x => x.manufacturingbayid,
                        principalTable: "ManufacturingBay",
                        principalColumn: "BayId");
                    table.ForeignKey(
                        name: "FK_Job_ProjectCategory_projectcategoryid",
                        column: x => x.projectcategoryid,
                        principalTable: "ProjectCategory",
                        principalColumn: "projectcategoryid");
                    table.ForeignKey(
                        name: "FK_Job_QualityLevel_qualitylevelid",
                        column: x => x.qualitylevelid,
                        principalTable: "QualityLevel",
                        principalColumn: "qualitylevelid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac241ec0-c0e5-4174-932f-4baf8024afa0", "AQAAAAEAACcQAAAAEBJHouThnCFoWkp/nITCFNWO2GzAD6XcxOL68L1bz1QCkhCbu5GEqo0you0Mhm4SXg==", "c76243c0-dfb6-4fa1-8ced-4ed912d0903c" });

            migrationBuilder.CreateIndex(
                name: "IX_Job_currencyid",
                table: "Job",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_customerid",
                table: "Job",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_isldapplicable",
                table: "Job",
                column: "isldapplicable");

            migrationBuilder.CreateIndex(
                name: "IX_Job_jobtypeid",
                table: "Job",
                column: "jobtypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_manufacturingbayid",
                table: "Job",
                column: "manufacturingbayid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_projectcategoryid",
                table: "Job",
                column: "projectcategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_projectengineerid",
                table: "Job",
                column: "projectengineerid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_projectmanagerid",
                table: "Job",
                column: "projectmanagerid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_qualitylevelid",
                table: "Job",
                column: "qualitylevelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f099f56-0f21-4998-8ca2-bcca6eceb7d6", "AQAAAAEAACcQAAAAEAwrBycXQUevjd9GIOVBs0HeZhgYw67qdvSoyOTBfpTDy9VOmhHZ9xreuvmS3GfAwQ==", "c9971d95-9b04-4465-a057-586d831c5b92" });
        }
    }
}
