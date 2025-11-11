using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddata3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enquiry",
                columns: table => new
                {
                    Enquiryref = table.Column<int>(type: "int", nullable: false),
                    enquirydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    customercontactid = table.Column<int>(type: "int", nullable: false),
                    projectmanagerid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    projectengineerid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    enquirytypeid = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquiry", x => x.Enquiryref);
                    table.ForeignKey(
                        name: "FK_Enquiry_AspNetUsers_projectengineerid",
                        column: x => x.projectengineerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enquiry_AspNetUsers_projectmanagerid",
                        column: x => x.projectmanagerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enquiry_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_Enquiry_customercontact_customercontactid",
                        column: x => x.customercontactid,
                        principalTable: "customercontact",
                        principalColumn: "customercontactid");
                    table.ForeignKey(
                        name: "FK_Enquiry_JobType_enquirytypeid",
                        column: x => x.enquirytypeid,
                        principalTable: "JobType",
                        principalColumn: "jobtypeid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9d616b3-183e-47bc-8ad8-8a8cc95d8fa1", "AQAAAAEAACcQAAAAEEKP1bCjjp398TZlR1HErEKNXHoXkbvgr2x9KL6nIOJjw+z4ZVf+yaadnUNS+H0n5A==", "fcdc4629-33a3-4285-89eb-55d9e783fe4b" });

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_customercontactid",
                table: "Enquiry",
                column: "customercontactid");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_customerid",
                table: "Enquiry",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_enquirytypeid",
                table: "Enquiry",
                column: "enquirytypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_projectengineerid",
                table: "Enquiry",
                column: "projectengineerid");

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_projectmanagerid",
                table: "Enquiry",
                column: "projectmanagerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enquiry");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9747c6ef-5c3b-4850-aa9d-63001452f2ee", "AQAAAAEAACcQAAAAEHjTkpuVYC4dYnCaWw8JB31fyWOzgwdiSkYNhpr8g3zZE9AHqyj36x+KkNkdpHHTuA==", "2d2da2a0-7744-492e-a783-1cd5cd462e2e" });
        }
    }
}
