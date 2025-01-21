using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addinventoryreservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4f46475-dda9-4961-aa18-7744b7c866c1", "AQAAAAEAACcQAAAAEEaegeuze0xxI3E73Lic41hgZROHVcRdheQkNBwW7MHeYjVUEuIIA9f5QZqzLT25yQ==", "d63ec666-1198-4123-85c7-84495baef498" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40410d59-2e96-4a18-87e4-a677cb478b38", "AQAAAAEAACcQAAAAEEojYV881N9MVuHfSKsLbNKXazp65p4+UqMqlrqPnzSeCEy0lOE8PzC1SB2+7ArCtA==", "30ff628d-b791-4709-9b1f-08c1c99bab2f" });
        }
    }
}
