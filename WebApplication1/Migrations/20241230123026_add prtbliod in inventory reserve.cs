using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addprtbliodininventoryreserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "prtblid",
                table: "Inventoryreservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff82b233-913e-4445-9ab0-97625b066858", "AQAAAAEAACcQAAAAENpSqQZ66qq9f6qQq1bEE08JoHDjrfkHFHd6bKtZvedBxH9WT0cjj/ZB/S6hAIIGLg==", "3ce5648d-eb89-48c1-963a-56ce0ce4503a" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_prtblid",
                table: "Inventoryreservation",
                column: "prtblid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventoryreservation_PRDetails_prtblid",
                table: "Inventoryreservation",
                column: "prtblid",
                principalTable: "PRDetails",
                principalColumn: "prtblid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventoryreservation_PRDetails_prtblid",
                table: "Inventoryreservation");

            migrationBuilder.DropIndex(
                name: "IX_Inventoryreservation_prtblid",
                table: "Inventoryreservation");

            migrationBuilder.DropColumn(
                name: "prtblid",
                table: "Inventoryreservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d85ebc9-68e3-4ad9-96de-4a8f6eb39fe5", "AQAAAAEAACcQAAAAEF+kLF+mg+yM3tztsIq2zO160sxQVu8Ijh1ZvQxTQIaXbfNn3a6oOOlZevCmeIujrQ==", "e22abb9b-0ece-4fc9-ba39-2c3cac3ee008" });
        }
    }
}
