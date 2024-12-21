using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class oo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pounitprice",
                table: "GRNHeader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01f07202-4815-4445-b722-699d0bd7a204", "AQAAAAEAACcQAAAAEJcPg8IfEdq5yGCyd0s5Lmp4SjiT/mBZLIVlnxwEWU75i9TwXoBy8z+Rl70yGMZtOQ==", "abc5a1b1-139e-4042-ac7c-050f317c6230" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "pounitprice",
                table: "GRNHeader",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b66e4029-4873-4595-80d8-4ac155ae1243", "AQAAAAEAACcQAAAAEEDDIcc2gWb8ZitdJ0vV6SvpB4+VDJlCwmYRKPE5YIaR0H69rj14usRuPGT7l1+a9g==", "152c7ff1-8cfb-47b1-a2ab-145d6093bd57" });
        }
    }
}
