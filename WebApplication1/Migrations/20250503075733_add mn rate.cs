using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmnrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "manhourrate",
                columns: table => new
                {
                    rateid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    manhourrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manhourrate", x => x.rateid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfb0145e-a6da-4c63-9d14-7da082299198", "AQAAAAEAACcQAAAAEKPpSr5PynFhzFnyEiIuQotZizRSDokge5kKrUEqjxsu0FKJYquZoERwW2JAGDljdA==", "7951e92d-3e6c-411b-b401-43af46184b56" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "manhourrate");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a05f5c1-42f9-4383-b4ca-d78b33df3417", "AQAAAAEAACcQAAAAEMebSdQ8DOrWCBIC+zff8WWTqgpSK6vHzYJKm8q4gdepboGX9mqyabq/UzUhb8GnzQ==", "a1307202-674c-409b-a7e9-fe24a481ce41" });
        }
    }
}
