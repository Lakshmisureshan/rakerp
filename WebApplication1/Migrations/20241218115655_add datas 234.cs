using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatas234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {




            migrationBuilder.AddColumn<int>(
                name: "invcurrencyid",
                table: "Inventory",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.Sql(@"
              UPDATE inventory
SET invcurrencyid = 1
            ");






            migrationBuilder.AddColumn<decimal>(
                name: "invprice",
                table: "Inventory",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaa0b984-8730-4472-b934-6cdb3b962d12", "AQAAAAEAACcQAAAAEADVItah5rOsJ/UP9iyoxbrFAbvoquYay9iwoZdOUSGLeWXgSBprMbw+5gDGSWd2mg==", "0079eda2-1ab9-47a8-86b7-b33b6047b181" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_invcurrencyid",
                table: "Inventory",
                column: "invcurrencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Currency_invcurrencyid",
                table: "Inventory",
                column: "invcurrencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Currency_invcurrencyid",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_invcurrencyid",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "invcurrencyid",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "invprice",
                table: "Inventory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2f8e715-2c63-4b8c-bbc6-6920a318c275", "AQAAAAEAACcQAAAAEMsoAtl3kAc229bIF47Q7Zh/kaUCF1xMgH5Vr9EVaRkXFjzmGQn9+MYYNUajnvn2+w==", "f6e46e20-1b61-43e2-a6a7-399de352022b" });
        }
    }
}
