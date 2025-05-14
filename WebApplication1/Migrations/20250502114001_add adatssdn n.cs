using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addadatssdnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "paymenterm1description",
                table: "PO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66608367-a0c5-4a63-87f2-8cd59770dc1c", "AQAAAAEAACcQAAAAENvhXKhX6U33aWgPEa+POizcPh/Y7Nd4WMOlmanFZLmReUh7NhqCBMSLFEiU0XyNbQ==", "25913d4d-44ea-4786-b166-8f0bfb9c0042" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymenterm1description",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6059ce82-f658-4522-9094-c4a624a21948", "AQAAAAEAACcQAAAAEJerSI5/nchcn9mpSsLO+wRuHu8z/44IhWqU13HHfJ6XKbP7eVzD12NYZI6wzy+W+Q==", "77cc293e-8647-4085-a13c-276998bb2e13" });
        }
    }
}
