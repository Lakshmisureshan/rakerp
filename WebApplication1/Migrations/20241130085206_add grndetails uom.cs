using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addgrndetailsuom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "inventoryuomid",
                table: "GRNDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pouomid",
                table: "GRNDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d81dc79-d63f-49cc-8aca-1af71046f4f2", "AQAAAAEAACcQAAAAEKiNapVruSPvlNn8W222QenlkP+0T1MfTwSoZWSsjr/uCuEDvXgBQVlL1WRmeewMZg==", "e29552d6-a465-49cd-9320-273b11b81ff2" });

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_inventoryuomid",
                table: "GRNDetails",
                column: "inventoryuomid");

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_pouomid",
                table: "GRNDetails",
                column: "pouomid");

            migrationBuilder.AddForeignKey(
                name: "FK_GRNDetails_UOM_inventoryuomid",
                table: "GRNDetails",
                column: "inventoryuomid",
                principalTable: "UOM",
                principalColumn: "uomid");

            migrationBuilder.AddForeignKey(
                name: "FK_GRNDetails_UOM_pouomid",
                table: "GRNDetails",
                column: "pouomid",
                principalTable: "UOM",
                principalColumn: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRNDetails_UOM_inventoryuomid",
                table: "GRNDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_GRNDetails_UOM_pouomid",
                table: "GRNDetails");

            migrationBuilder.DropIndex(
                name: "IX_GRNDetails_inventoryuomid",
                table: "GRNDetails");

            migrationBuilder.DropIndex(
                name: "IX_GRNDetails_pouomid",
                table: "GRNDetails");

            migrationBuilder.DropColumn(
                name: "inventoryuomid",
                table: "GRNDetails");

            migrationBuilder.DropColumn(
                name: "pouomid",
                table: "GRNDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "109167e7-d807-4207-a4e4-62a91ba4cd51", "AQAAAAEAACcQAAAAEJ+AbCaqr6hVlj1cMo4I7jRZovGXX1a4UWzgHsCj5AprroS0gkkPiQQoytUTIRnZDA==", "c62b5c55-546c-46e0-a8c9-be42c81ffcb9" });
        }
    }
}
