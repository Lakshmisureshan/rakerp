using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class sdbfjsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "manufacturingbayid",
                table: "Job",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5a9f77b6-a33a-46dd-a08a-a40f813b678f", "AQAAAAEAACcQAAAAEPDAglnIk0DAi30OcRB38euyYbE8DPaxTbWSNs64HF9CkD9JIderLzq3lIW49532fw==", "13b739b3-4b2e-4564-838a-9066fccc88c9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "manufacturingbayid",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9009696-3546-4b76-98b8-6dfae439310b", "AQAAAAEAACcQAAAAEPUsLHPP0qkyjdAeNa/qVxnyAbdDLUR8Z+QCAEPESgZzcpsnRE+vvlMFt8fJnN4QHA==", "470bd013-ece9-492c-ac11-4d92eb0632e1" });
        }
    }
}
