using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpruexpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "pruexpense1",
                table: "Job",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "pruexpense2",
                table: "Job",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39851c8e-a02b-45f2-8c25-9dec959c917c", "AQAAAAEAACcQAAAAEChj5J2tGSQdVYNyFPWgYVjAj4xBmQ1BFl7xRGbCFsnuAA7hmTQuBT74olC+9PUrJA==", "14f7668c-81bf-459e-95c6-717002fa58e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pruexpense1",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "pruexpense2",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2222fffe-2baa-492a-bb9c-def8ac8a1d5a", "AQAAAAEAACcQAAAAEIqZH/YIhzWcV2Z8N+HyLn/hgbAJwlIe5pF0CFsTaoEyCVByroibX+QGftf1J8Ugqg==", "e32b48cf-ac87-4e71-82f8-f5483f5ea3d4" });
        }
    }
}
