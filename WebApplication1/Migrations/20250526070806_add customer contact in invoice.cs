using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcustomercontactininvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Add the column with no default
            migrationBuilder.AddColumn<int>(
                name: "customercontactid",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0); // Required for non-nullable column; we will overwrite this next

            // 2. Manually update all existing rows to 1
            migrationBuilder.Sql("UPDATE Invoice SET customercontactid = 2");

            // 3. Create index and foreign key
            migrationBuilder.CreateIndex(
                name: "IX_Invoice_customercontactid",
                table: "Invoice",
                column: "customercontactid");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_customercontact_customercontactid",
                table: "Invoice",
                column: "customercontactid",
                principalTable: "customercontact",
                principalColumn: "customercontactid");

            // 4. Update AspNetUsers data (if needed by your app)
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[]
                {
                    "015fb374-e96b-4146-bf38-7ac19cbaeff2",
                    "AQAAAAEAACcQAAAAEGOhAxQkoV2D/ADqw4eIF5VWEgMNfnCHLc4oFrii+3YwzOPKty8+w/IPfcTKveljBg==",
                    "c8f0d177-4ab8-462a-bda3-a60fa5f38fb6"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Rollback steps
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_customercontact_customercontactid",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_customercontactid",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "customercontactid",
                table: "Invoice");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[]
                {
                    "dd7073ee-b203-41c7-a171-689d0fe89f89",
                    "AQAAAAEAACcQAAAAEF1EdowsdrCjPR9VmcaPnVI4dMuRx8aBgg6lhID71rA1eTyVBPp1yWlZGJHOwLSjpg==",
                    "e275bd33-d9ae-4308-983d-2af857427898"
                });
        }
    }
}
