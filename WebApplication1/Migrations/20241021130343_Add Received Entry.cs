using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddReceivedEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceivedEntry",
                columns: table => new
                {
                    REID = table.Column<int>(type: "int", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    REDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedEntry", x => x.REID);
                    table.ForeignKey(
                        name: "FK_ReceivedEntry_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e6581f6-df92-4014-bc9d-ee9f96f380e7", "AQAAAAEAACcQAAAAEHwJl/tiZw+49ipYiOxuN5znClT1aZGG7lT50wzN8qgWRzp71Aiysf6Nnbw/1So8gw==", "787d1ed2-a03b-47aa-b6db-a6f3974fd5ac" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntry_pono",
                table: "ReceivedEntry",
                column: "pono");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivedEntry");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "315a23e8-d0f7-4fc9-92fe-ac5ee5572e17", "AQAAAAEAACcQAAAAEAW7Eo6J1rKPK+3el90z3p+YvyYERze0mBwHCIEqbBUGfQ3v7Ja+aJt+sZta09wxKg==", "57bc0405-092c-47a4-b5c4-d7c1700bf629" });
        }
    }
}
