using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addconytactdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customercontact",
                columns: table => new
                {
                    customercontactid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customercontact", x => x.customercontactid);
                    table.ForeignKey(
                        name: "FK_customercontact_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d6ce0f-c9dc-469a-b961-e10f0d30380e", "AQAAAAEAACcQAAAAEMFrmLSw0E3NhfIJtgRnq76t6tHJQ5rEBJPP0gi7wCTCOXJiwam8eUd+db5/e4Z/xw==", "3bd58126-0c45-49c0-9834-4d7cf94ba97d" });

            migrationBuilder.CreateIndex(
                name: "IX_customercontact_customerid",
                table: "customercontact",
                column: "customerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customercontact");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbfb2dbd-d1a4-4e7b-997d-090cd235e062", "AQAAAAEAACcQAAAAECC/Z7SIA/GmgRQ6aCYI12NXjG9g/F4dWGcqyetKaL49DGPk44ksPbXOmgg2naItAA==", "34bbae38-3319-4fb2-aa04-d366afaa4449" });
        }
    }
}
