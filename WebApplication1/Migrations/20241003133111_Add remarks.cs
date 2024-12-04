using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addremarks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "PO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b8aefa7-6a49-4812-92ff-bbcd834b480d", "AQAAAAEAACcQAAAAEIX3KzER3CMpxwoUDyDCG2mlUOUmxtyRVegphtM9gRK+bfcVUeNZxDJ1DIQMXLe+Yg==", "d262265e-5155-4b47-984d-40d0987c6d6e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e671339-903f-4659-91da-ec39e97852dd", "AQAAAAEAACcQAAAAEFxx52tFQvdvqTt/0iBFX4qF7GBclEb+4Z1YSOw7NaFhB6P23H9nlvBwwC0s59aTFg==", "a7f48bad-d410-44e2-ad8d-c3cd5abd9170" });
        }
    }
}
