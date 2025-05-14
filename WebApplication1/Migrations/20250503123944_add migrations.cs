using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "mrate",
                table: "manhour",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eecf9ed9-5899-4613-8cb2-e1218974ac98", "AQAAAAEAACcQAAAAEL/olyOjivfQEk446pQJQyBlhi91AeptveHxI5pmpFOTKYvGeXNXzMuogHawhtXTig==", "cbf61bc5-e947-450f-91da-22684c260bc4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mrate",
                table: "manhour");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cfb0145e-a6da-4c63-9d14-7da082299198", "AQAAAAEAACcQAAAAEKPpSr5PynFhzFnyEiIuQotZizRSDokge5kKrUEqjxsu0FKJYquZoERwW2JAGDljdA==", "7951e92d-3e6c-411b-b401-43af46184b56" });
        }
    }
}
