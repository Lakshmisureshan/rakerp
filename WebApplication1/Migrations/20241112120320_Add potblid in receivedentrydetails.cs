using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addpotblidinreceivedentrydetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "potblid",
                table: "ReceivedEntryDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33f3fbe5-b047-4c3b-a02e-d8d5d68f2639", "AQAAAAEAACcQAAAAEFn7FDybtSMUBxj2J91Dyb+FXGjyB6AhofGt+qaSluEDPTGEPubyNzh9UuPJnVV0cw==", "e910719c-a1c0-42da-a9ca-ed90b16467d3" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntryDetails_potblid",
                table: "ReceivedEntryDetails",
                column: "potblid");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedEntryDetails_Purchasedetails_potblid",
                table: "ReceivedEntryDetails",
                column: "potblid",
                principalTable: "Purchasedetails",
                principalColumn: "potblid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedEntryDetails_Purchasedetails_potblid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedEntryDetails_potblid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropColumn(
                name: "potblid",
                table: "ReceivedEntryDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbaf534f-dc40-4c8f-9960-8713d20b9b17", "AQAAAAEAACcQAAAAEAqLuw1ZvbS+njZzT/9rKxI6F2JKvc4BNXKZZomtNXcbEExsAe16N8NPKGX7w376oA==", "e2b8efbc-3b48-4af8-9b69-a14f2956cb46" });
        }
    }
}
