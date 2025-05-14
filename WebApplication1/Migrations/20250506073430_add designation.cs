using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddesignation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "designation",
                columns: table => new
                {
                    designationid = table.Column<int>(type: "int", nullable: false),
                    designationname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designation", x => x.designationid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "473bf673-aad3-4cc1-b170-bd2891cfc983", "AQAAAAEAACcQAAAAEMspJMYu1gqMmXAqbk1+1a34d9TA9dsBkPvQDjOnhWHZ/rbJV4uAuiTxW2R0Bw1CVQ==", "63fb3eed-a3c4-4c73-9eef-f11a4de489de" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "designation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eecf9ed9-5899-4613-8cb2-e1218974ac98", "AQAAAAEAACcQAAAAEL/olyOjivfQEk446pQJQyBlhi91AeptveHxI5pmpFOTKYvGeXNXzMuogHawhtXTig==", "cbf61bc5-e947-450f-91da-22684c260bc4" });
        }
    }
}
