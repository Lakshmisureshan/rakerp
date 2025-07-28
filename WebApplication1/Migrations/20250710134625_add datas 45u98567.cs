using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatas45u98567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ldpercent",
                table: "Job",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7a3122c-e7e9-43ca-a28d-581fb4a82da9", "AQAAAAEAACcQAAAAEGfCdegCH4yHvORE3ZbLIfR6KjW30o/OYwu/kyLIBBGNwNyvfgs5ft0Lj1IrATY6KA==", "21efc2b8-e902-4c88-b8aa-cc4bf6447e1c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ldpercent",
                table: "Job",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a9f77b6-a33a-46dd-a08a-a40f813b678f", "AQAAAAEAACcQAAAAEPDAglnIk0DAi30OcRB38euyYbE8DPaxTbWSNs64HF9CkD9JIderLzq3lIW49532fw==", "13b739b3-4b2e-4564-838a-9066fccc88c9" });
        }
    }
}
