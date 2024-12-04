using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddprpocreatedqtytoPR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "pocreatedqty",
                table: "PRDetails",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54998d36-42a7-4d84-bd4d-306e86ef93b9", "AQAAAAEAACcQAAAAEF6Dfo5mWA+rDdrN8hgu9AqYDZD1Gon8TsoPJ52Sen0biKesTaQRvWih+26Y49p4tw==", "d43b14ed-8847-48d8-8795-d6a299ba3e54" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pocreatedqty",
                table: "PRDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6831f4ad-f46b-4209-bab6-408781360c42", "AQAAAAEAACcQAAAAECaq2ECCGVOVbAu1RP6/KZ64XO3+OH2YZp0SNZP/v+OocyxZ76wP9Foxkl38bygZHg==", "05d84d0f-911e-4184-8690-4a86cfeba038" });
        }
    }
}
