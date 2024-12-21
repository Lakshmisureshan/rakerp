using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addgrnunitprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pounitprice",
                table: "GRNHeader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9e7eb43-9215-46c6-a05f-c09702222b6f", "AQAAAAEAACcQAAAAEB2vXdOlV47LNst8k8Z3PsH4/oHWFrlFOZUwC/Ti9Jd1UOOtfekeLlpnFXfgD401jQ==", "b3c376b2-d140-442a-bfa0-d0c3e93f1e92" });
        }
    }
}
