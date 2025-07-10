using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatasdeliverynote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryNote",
                columns: table => new
                {
                    deliveryno = table.Column<int>(type: "int", nullable: false),
                    deliverydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    buyerid = table.Column<int>(type: "int", nullable: false),
                    buyerdeliveryaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buyertrnno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyeriec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyercontactid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    buyerlpono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    buyerlpodate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    consigneename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consigneeaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consigneelpono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consigneelpodate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consigneetrnno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    consigneeiec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vehicleno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receivedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deliveredby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryNote", x => x.deliveryno);
                    table.ForeignKey(
                        name: "FK_DeliveryNote_Customer_buyerid",
                        column: x => x.buyerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_DeliveryNote_customercontact_buyercontactid",
                        column: x => x.buyercontactid,
                        principalTable: "customercontact",
                        principalColumn: "customercontactid");
                    table.ForeignKey(
                        name: "FK_DeliveryNote_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69dd3478-2e41-4cff-82d8-93b726001aab", "AQAAAAEAACcQAAAAEDf5/rHuuDC6B6jQGJWYRa8mplM6BnDGB/vn8xvGaxPOXjFYRbd212ylUZ+hOX1gQQ==", "30ea363a-f203-4eee-8ea0-171f90e50f11" });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_buyercontactid",
                table: "DeliveryNote",
                column: "buyercontactid");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_buyerid",
                table: "DeliveryNote",
                column: "buyerid");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryNote_jobid",
                table: "DeliveryNote",
                column: "jobid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryNote");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0124c475-ed51-4a0f-8c9a-1819a3098824", "AQAAAAEAACcQAAAAEN12K63gZSv5pfniMLbthfv4qCViZx1tc5l4Fb67jhD2fIaeJWDdMAJZsUAlOKfMqA==", "2261b867-dc8e-4b4f-978b-ab5f3c6ecb79" });
        }
    }
}
