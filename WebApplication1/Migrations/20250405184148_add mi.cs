using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materialinspection",
                columns: table => new
                {
                    mid = table.Column<int>(type: "int", nullable: false),
                    midate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false),
                    reid = table.Column<int>(type: "int", nullable: false),
                    isregistered = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qtyverified = table.Column<bool>(type: "bit", nullable: false),
                    phycondn = table.Column<bool>(type: "bit", nullable: false),
                    heattags = table.Column<bool>(type: "bit", nullable: false),
                    colorcoding = table.Column<bool>(type: "bit", nullable: false),
                    siteidentification = table.Column<bool>(type: "bit", nullable: false),
                    correlation = table.Column<bool>(type: "bit", nullable: false),
                    tcverify = table.Column<bool>(type: "bit", nullable: false),
                    materialsent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materialinspection", x => x.mid);
                    table.ForeignKey(
                        name: "FK_Materialinspection_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                    table.ForeignKey(
                        name: "FK_Materialinspection_ReceivedEntry_reid",
                        column: x => x.reid,
                        principalTable: "ReceivedEntry",
                        principalColumn: "REID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5440739c-e1c8-4638-90bc-7302974f8289", "AQAAAAEAACcQAAAAEI14WRH904cLetYwi59g05LnS2yXXropyoPQH/FOqBWTQuGZtYJLF6YXYzyNsev/7A==", "05932362-c4a3-44e9-8c71-1279cf09e3c6" });

            migrationBuilder.CreateIndex(
                name: "IX_Materialinspection_pono",
                table: "Materialinspection",
                column: "pono");

            migrationBuilder.CreateIndex(
                name: "IX_Materialinspection_reid",
                table: "Materialinspection",
                column: "reid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materialinspection");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af8f6281-a854-40e1-9d72-01572dc2e28a", "AQAAAAEAACcQAAAAENo4rgmReSVppEb/w0UyiJ4cHb1OyPeMNuIYAs6aSP79WeBWjN+fJo2Bg0Cna9M/Jg==", "7ac5fdf7-285c-456d-8b74-551101ca3256" });
        }
    }
}
