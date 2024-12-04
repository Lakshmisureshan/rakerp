using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addgrnheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRNHeader",
                columns: table => new
                {
                    grnno = table.Column<int>(type: "int", nullable: false),
                    grndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNHeader", x => x.grnno);
                    table.ForeignKey(
                        name: "FK_GRNHeader_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3d91eb2-b35f-4839-aaff-f84fdf69624a", "AQAAAAEAACcQAAAAEKw/jloMPixsL8exOFE43BHHB8ClqmEoJYsbFjXjakx9WEO/mgfpThzTvAIzdQE7Mw==", "0d341835-eb10-49b7-b7f4-e95e38f11f43" });

            migrationBuilder.CreateIndex(
                name: "IX_GRNHeader_pono",
                table: "GRNHeader",
                column: "pono");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRNHeader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d598e8c9-bf50-4208-9173-bf4a0bf913cd", "AQAAAAEAACcQAAAAEIfPogtkDKPRdFFHC38IjcQWUpmun/UE4fAew1/r80UqC6Zm7ijB8Vwr9Nyuw7RMEQ==", "00666563-f7a8-401f-ab76-5a0be2e23070" });
        }
    }
}
