using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addinspaccptedqty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "inspacceptedqty",
                table: "Purchasedetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d598e8c9-bf50-4208-9173-bf4a0bf913cd", "AQAAAAEAACcQAAAAEIfPogtkDKPRdFFHC38IjcQWUpmun/UE4fAew1/r80UqC6Zm7ijB8Vwr9Nyuw7RMEQ==", "00666563-f7a8-401f-ab76-5a0be2e23070" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "inspacceptedqty",
                table: "Purchasedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33f3fbe5-b047-4c3b-a02e-d8d5d68f2639", "AQAAAAEAACcQAAAAEFn7FDybtSMUBxj2J91Dyb+FXGjyB6AhofGt+qaSluEDPTGEPubyNzh9UuPJnVV0cw==", "e910719c-a1c0-42da-a9ca-ed90b16467d3" });
        }
    }
}
