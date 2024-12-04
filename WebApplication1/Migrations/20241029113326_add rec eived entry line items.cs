using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addreceivedentrylineitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceivedEntryDetails",
                columns: table => new
                {
                    rtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RENO = table.Column<int>(type: "int", nullable: false),
                    receivedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedEntryDetails", x => x.rtblid);
                    table.ForeignKey(
                        name: "FK_ReceivedEntryDetails_ReceivedEntry_RENO",
                        column: x => x.RENO,
                        principalTable: "ReceivedEntry",
                        principalColumn: "REID");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "043a365f-4586-415c-b578-fbe926e9b9cb", "AQAAAAEAACcQAAAAEOt40a/oQ89u0gjzXFYVfQ8WB7iJnhD5h2FKPrnw34HpzUpTRUADJcetgL2XZdHyuQ==", "db468e73-3ca9-406b-89c0-eb797124fbaf" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntryDetails_RENO",
                table: "ReceivedEntryDetails",
                column: "RENO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivedEntryDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d508f5bc-2102-42f0-970b-400c86d2205c", "AQAAAAEAACcQAAAAEM2o9W4e4gDNe/aPddgbqlbFRPbmslFVIEC/xCYB3Zc/t9gf4mv2ZPNYnI7MttOEYw==", "ccb4cbe1-7f05-44a9-af29-4c950208e0e6" });
        }
    }
}
