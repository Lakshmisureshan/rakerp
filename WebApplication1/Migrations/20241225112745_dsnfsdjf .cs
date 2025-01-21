using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dsnfsdjf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f4f46475-dda9-4961-aa18-7744b7c866c1", "AQAAAAEAACcQAAAAEEaegeuze0xxI3E73Lic41hgZROHVcRdheQkNBwW7MHeYjVUEuIIA9f5QZqzLT25yQ==", "d63ec666-1198-4123-85c7-84495baef498" });
        }
    }
}
