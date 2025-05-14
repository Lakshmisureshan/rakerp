using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmanhourrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a05f5c1-42f9-4383-b4ca-d78b33df3417", "AQAAAAEAACcQAAAAEMebSdQ8DOrWCBIC+zff8WWTqgpSK6vHzYJKm8q4gdepboGX9mqyabq/UzUhb8GnzQ==", "a1307202-674c-409b-a7e9-fe24a481ce41" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5837a014-cca2-45df-9fd7-9c943fabca26", "AQAAAAEAACcQAAAAEEwQmZnV4Ib/ZkmKwEeErtsh5cRQ1zCxoU1aITxL0fkAeYepV85wTBDiqWqYfVRXYg==", "9d9a8a7c-9030-4a29-a33d-2fbe821c5566" });
        }
    }
}
