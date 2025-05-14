using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addemployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employeemaster",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false),
                    empname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empstatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeemaster", x => x.empid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d587ed56-3278-47d6-abfc-dccbf27965da", "AQAAAAEAACcQAAAAECST5H2UTf1zfymEuBqUz4ntflywdjUtqr5wHc83/aPgpwroB2CiR+tUagak9lR2OQ==", "92b06ec3-2e12-4aa8-a86f-80d91f8daed7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employeemaster");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53867036-198f-4813-985b-16b91dfbfee6", "AQAAAAEAACcQAAAAEEIQ0ZrI5dVVObZgPP1Ey9ztnvaqygUMuzxDz9n+36VFF8kkBg3hYk+a9gSRujJGKA==", "c81f36e0-f4af-488c-9ea6-f3cb6ce238bd" });
        }
    }
}
