using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class fgfhjdhed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17226b04-b1a6-463b-a0b5-5fc558ba2c41", "AQAAAAEAACcQAAAAEB3DKFPkuusouI8lN097E/9LeOyvYNVRF+SVCJW4MFg0lTIJJNGYigkBoEfn987mHQ==", "849cdc78-d2ad-417d-8521-58dbcb8151d1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e32cb79-86d3-4072-acde-c7dc55d30def", "AQAAAAEAACcQAAAAEPwJ0W3UkY4K1Rp7vkVHJ5ANfJ9po2VB8TV8Bs0bmCcxZwvl4NqKv2NohLE3Lq6orA==", "0e0aaab4-de01-445c-9193-2da206212eb2" });
        }
    }
}
