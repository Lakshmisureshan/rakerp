using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addtotalinvoicinginjob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "totalinvoiceinbasecurrency",
                table: "Job",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ff24f01-150b-419f-959e-9cddf8c6d185", "AQAAAAEAACcQAAAAEKfDXVJl/l4yjZmyxAmhUKzOxjAuGjtxmCAgUUigIHfeSIU18JuW7wCj+hepdUqJUg==", "8dea23a1-b16d-4b1e-b8f4-58592db7410e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalinvoiceinbasecurrency",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "431e37fa-b432-45df-8921-3e0cdba8b70b", "AQAAAAEAACcQAAAAELzhCDj2qWlXq7DYe8BMk/67wvB5rGtBbMuaEvPCWNU4kMoVjezpbMVfrC3pjEUBSQ==", "e8141e08-239f-46d8-8995-fdbb03490ef1" });
        }
    }
}
