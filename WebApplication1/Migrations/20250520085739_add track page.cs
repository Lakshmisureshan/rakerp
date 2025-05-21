using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addtrackpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trackpage",
                columns: table => new
                {
                    trackid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pagename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    docno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdbyuser = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trackpage", x => x.trackid);
                    table.ForeignKey(
                        name: "FK_Trackpage_AspNetUsers_createdbyuser",
                        column: x => x.createdbyuser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "962cfa32-5e35-4c6e-b38f-23875dc13061", "AQAAAAEAACcQAAAAEHHiU1sEv0Dyya3G4zh68ZVAv0/IVTebWVEwzp5pc4mo8F0LT1YL636b+uba3bZE+Q==", "822d78f6-4973-411c-b3c9-329936e6bdd2" });

            migrationBuilder.CreateIndex(
                name: "IX_Trackpage_createdbyuser",
                table: "Trackpage",
                column: "createdbyuser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trackpage");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df7a3f80-b771-4888-bbbf-e6b90e88b481", "AQAAAAEAACcQAAAAEOeRSkQvSNguMwzdRcc4/XL0reuSX5VBY3C4UkKvBjMSWmp5Bm4kZlzCXlHO/wNqpg==", "b2616bbe-8c24-485d-a51e-4aa3483431f7" });
        }
    }
}
