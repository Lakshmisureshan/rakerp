using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuenote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "quantity",
                table: "Inventory",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fb31ac8-ba84-4cc4-ae54-6a0a59df9d5a", "AQAAAAEAACcQAAAAEDkEviMur4weBF80zubxswvcizN6LhefIiXR2SnUWkyzU5CwpcAo1zv04bUh/J/Azg==", "2c78f0ed-ee85-4032-821d-e39f8cb16291" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "quantity",
                table: "Inventory",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a77a2b3e-957f-4c27-9c12-57c78e29b86e", "AQAAAAEAACcQAAAAEL8vX7Rw6Qpbw5IwxmR55Ewq9zlJYEiVFqFWM7EC0zQvGopoSt1Jq5FW/hE8bv+XTA==", "2ee5df6e-b5c6-426b-830c-1da5b2c66223" });
        }
    }
}
