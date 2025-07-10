using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class fnerref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0d07314-6b3c-44d4-9045-af87db627ee7", "AQAAAAEAACcQAAAAEHMJeRBumbR+i0TSEce/ib4fdFagFswWc4wWKNmkqx6hq9Gv5G9lR1ziIzQNRPiPgA==", "ad942da9-af5e-499e-acb7-71b583b95739" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c84de57-5ae2-435a-8489-a049a782bad3", "AQAAAAEAACcQAAAAEMJWP0gwGAVpJuXpR7X/44cZpmzJ5x8N/55rplGHEfIc84VKJ1729RIWizhgHu6J7w==", "da7bdec1-c75e-47b0-bd6b-b7e1ae7893f6" });
        }
    }
}
