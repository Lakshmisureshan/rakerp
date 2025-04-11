using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addholdandaccepin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "inspholdqty",
                table: "Purchasedetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "insprejectedqty",
                table: "Purchasedetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3780c34a-c6fa-4884-86a4-1a0595624d30", "AQAAAAEAACcQAAAAEMtn9Pn/H9ywf0vT3JfH0Ed/LPH6N4/xDsjJcn+FA18M96Opfk7gH609ox7RpNmG8A==", "098a0cf5-9aa3-4403-ab5b-3ca1e9c6dd92" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inspholdqty",
                table: "Purchasedetails");

            migrationBuilder.DropColumn(
                name: "insprejectedqty",
                table: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bab6e432-8da3-4d2c-aef9-dd9df10d5628", "AQAAAAEAACcQAAAAEFW/PzBTm4Vv+ze/mFI/j1Y3/uFa7WiTknVmFnVsXejXH1ldvvnDAQZkQt2pVOv0vw==", "6f36a713-a8e2-4e71-bdbe-27fc4fceba22" });
        }
    }
}
