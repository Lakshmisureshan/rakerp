using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddeliverydetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deliverydetails",
                columns: table => new
                {
                    did = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryid = table.Column<int>(type: "int", nullable: false),
                    srno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    counter = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliverydetails", x => x.did);
                    table.ForeignKey(
                        name: "FK_deliverydetails_DeliveryNote_deliveryid",
                        column: x => x.deliveryid,
                        principalTable: "DeliveryNote",
                        principalColumn: "deliveryno");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcd1c2f9-54cb-4e5d-873f-5d403799aa14", "AQAAAAEAACcQAAAAENPpdMXS0AFakVw/24c/LRzKFwQ5tJv1+l+i+9zMEpoGlZoENMpjbbLBNw2prbyYVQ==", "02c177b2-8fb0-40fa-b436-6f37bc2e6402" });

            migrationBuilder.CreateIndex(
                name: "IX_deliverydetails_deliveryid",
                table: "deliverydetails",
                column: "deliveryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliverydetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69dd3478-2e41-4cff-82d8-93b726001aab", "AQAAAAEAACcQAAAAEDf5/rHuuDC6B6jQGJWYRa8mplM6BnDGB/vn8xvGaxPOXjFYRbd212ylUZ+hOX1gQQ==", "30ea363a-f203-4eee-8ea0-171f90e50f11" });
        }
    }
}
