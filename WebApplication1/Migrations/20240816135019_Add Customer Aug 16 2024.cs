using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddCustomerAug162024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    countryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.countryid);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ccode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shortname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trnno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IEC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pobox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    web = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerid);
                    table.ForeignKey(
                        name: "FK_Customer_Country_countryid",
                        column: x => x.countryid,
                        principalTable: "Country",
                        principalColumn: "countryid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_countryid",
                table: "Customer",
                column: "countryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
