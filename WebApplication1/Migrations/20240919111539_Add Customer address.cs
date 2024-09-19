using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddCustomeraddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f42279bd-4e8c-4f07-9cf8-dc6161837752", "AQAAAAEAACcQAAAAEJ8DLj8DoaxZSu9P3kK6cPCM1NwjxpQcwhn+ZvNJhq7h93pR5t/GphIMaYlpxTaVfg==", "18c415a5-5744-49b0-9bbd-753d9748069b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Customer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ef29232-9305-4d51-93fc-24d58b35cd68", "AQAAAAEAACcQAAAAELo37CVHmf9be5G7JBJ8cAKO8VbFuODLRH2rRrQQ+fSVtJ35ZwqW6QajF+XUbJuYkA==", "478d9e07-3850-46cf-b07c-4630f01c7dac" });
        }
    }
}
