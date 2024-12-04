using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addgrncreatedqty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "grncreatedqty",
                table: "Purchasedetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3239e90-f89c-4a4e-b94b-a41adc599d80", "AQAAAAEAACcQAAAAEFh76skiX31QI7tABMlghNUseLNkZ2uaZ/lMLeCbCEwRClTpoy6qHZO2dIUawAQMIg==", "ea74dea8-b881-494c-973f-9bc054bd49ee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "grncreatedqty",
                table: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3d91eb2-b35f-4839-aaff-f84fdf69624a", "AQAAAAEAACcQAAAAEKw/jloMPixsL8exOFE43BHHB8ClqmEoJYsbFjXjakx9WEO/mgfpThzTvAIzdQE7Mw==", "0d341835-eb10-49b7-b7f4-e95e38f11f43" });
        }
    }
}
