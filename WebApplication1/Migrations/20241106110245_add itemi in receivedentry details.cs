using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class additemiinreceivedentrydetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Productitemid",
                table: "ReceivedEntryDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "itemid",
                table: "ReceivedEntryDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98befd72-3683-4bf1-98f5-48a59add187a", "AQAAAAEAACcQAAAAEO/VVOWGsvQtdk6Inea0MS5tcKsAy/7eKaJzgXZDfH939vgITErQvZThVDjMBBwnLA==", "46444aba-372b-4cb8-91ca-8cd9883b587b" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntryDetails_Productitemid",
                table: "ReceivedEntryDetails",
                column: "Productitemid");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedEntryDetails_Product_Productitemid",
                table: "ReceivedEntryDetails",
                column: "Productitemid",
                principalTable: "Product",
                principalColumn: "itemid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedEntryDetails_Product_Productitemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedEntryDetails_Productitemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropColumn(
                name: "Productitemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropColumn(
                name: "itemid",
                table: "ReceivedEntryDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "043a365f-4586-415c-b578-fbe926e9b9cb", "AQAAAAEAACcQAAAAEOt40a/oQ89u0gjzXFYVfQ8WB7iJnhD5h2FKPrnw34HpzUpTRUADJcetgL2XZdHyuQ==", "db468e73-3ca9-406b-89c0-eb797124fbaf" });
        }
    }
}
