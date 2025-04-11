using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatafff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "itembname",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2222fffe-2baa-492a-bb9c-def8ac8a1d5a", "AQAAAAEAACcQAAAAEIqZH/YIhzWcV2Z8N+HyLn/hgbAJwlIe5pF0CFsTaoEyCVByroibX+QGftf1J8Ugqg==", "e32b48cf-ac87-4e71-82f8-f5483f5ea3d4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itembname",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fcbb250-2567-48b5-9e4c-9e61615f9473", "AQAAAAEAACcQAAAAEMZDcagY+f+Ai737jjPlrvfYivdhTm78cheFca9sUsE3zKuXNozXcBs3N2JsYVCAmw==", "7e1b1d7b-7828-4ba1-a115-09f41ce3624f" });
        }
    }
}
