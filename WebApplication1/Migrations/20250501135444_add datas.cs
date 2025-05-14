using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventoryreservation_Inventory_inventoryid",
                table: "Inventoryreservation");

            migrationBuilder.DropIndex(
                name: "IX_Inventoryreservation_inventoryid",
                table: "Inventoryreservation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae5bcc96-af5f-4d55-bca5-e6c692936a9c", "AQAAAAEAACcQAAAAEFWjZ7skdGZTkx2IC9zHoOzDpjOVOwuOJJca7ZPxDjtdEKZ342ouU6QjjBBrfLHcmQ==", "84c9a459-0cb3-41dc-ae3c-2771e7422761" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8e3f613-8138-4cd9-9f33-6fcc8a137273", "AQAAAAEAACcQAAAAEMCp5QNdfc6Mz3dyWz7AfCiM61WmCcYnSIxvmiTeFn5F2uEkPAEz5aoVfkL0LiJjLg==", "637b1133-c950-46f5-8169-9422cb4d4e04" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_inventoryid",
                table: "Inventoryreservation",
                column: "inventoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventoryreservation_Inventory_inventoryid",
                table: "Inventoryreservation",
                column: "inventoryid",
                principalTable: "Inventory",
                principalColumn: "invid");
        }
    }
}
