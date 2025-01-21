using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class mghfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "invunitprice",
                table: "Inventoryreservation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "issuecreatedqty",
                table: "Inventoryreservation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c86c0196-fd5a-4cbd-b318-7c14058b3efb", "AQAAAAEAACcQAAAAECjLp1+8F1dHchJOjnpeh2jGn09PjiVGudJmhuhi7x1WRvBvEpr8qywdH0D0TJeYIQ==", "390dfb76-b71f-421f-899a-e70bbd7b7915" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "invunitprice",
                table: "Inventoryreservation");

            migrationBuilder.DropColumn(
                name: "issuecreatedqty",
                table: "Inventoryreservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f037c71-46fc-4077-8f76-f016d0fa4021", "AQAAAAEAACcQAAAAEDdfAuXMZNnDUByVrfSsURRCJY9Y+sPKl9Mh6TW2IAKJ6kqY9CEwgHlw14sLrq3vTA==", "ca85a712-fcfb-4079-aa34-eaf247c492ea" });
        }
    }
}
