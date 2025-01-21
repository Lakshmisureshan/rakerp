using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addcurrencyininvreserv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "invrcurrencyid",
                table: "Inventoryreservation",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.Sql(@"
              UPDATE inventoryreservation
SET invrcurrencyid = inventory.invcurrencyid 
FROM inventory
WHERE inventory.invid = inventoryreservation.inventoryid;
            ");












            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc37d960-a9f5-492b-a49f-c0d163136b71", "AQAAAAEAACcQAAAAEFXvecNysWaZltjDBxi918CmqSAiHLFLU9FXOqEcANzI1RFaT/jHVqcSyQJ6hj3hTA==", "66814c52-9ade-483b-84ff-575fc589fccf" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_invrcurrencyid",
                table: "Inventoryreservation",
                column: "invrcurrencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventoryreservation_Currency_invrcurrencyid",
                table: "Inventoryreservation",
                column: "invrcurrencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventoryreservation_Currency_invrcurrencyid",
                table: "Inventoryreservation");

            migrationBuilder.DropIndex(
                name: "IX_Inventoryreservation_invrcurrencyid",
                table: "Inventoryreservation");

            migrationBuilder.DropColumn(
                name: "invrcurrencyid",
                table: "Inventoryreservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d5362f-1ded-455f-8d92-11a676100d90", "AQAAAAEAACcQAAAAEAi4+pvGqVmsJfSPV744CnDApUkpgTVgORtSf2R05AiiaKp3cxCfzGu5p1Eko4P0EA==", "ebb776bf-b63f-4978-b80f-97ecf9fd9e50" });
        }
    }
}
