using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class manhourcreateddate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createddate",
                table: "manhour",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5837a014-cca2-45df-9fd7-9c943fabca26", "AQAAAAEAACcQAAAAEEwQmZnV4Ib/ZkmKwEeErtsh5cRQ1zCxoU1aITxL0fkAeYepV85wTBDiqWqYfVRXYg==", "9d9a8a7c-9030-4a29-a33d-2fbe821c5566" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createddate",
                table: "manhour");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c09c51c5-1e9b-4325-8c09-6eeb2b740b74", "AQAAAAEAACcQAAAAEBw3RsDS6UoZPaWBexIXzwZFNHIpSCebYW0f9U+pMgF6LbcBmxMI3exr9kgFD4YFDA==", "a7b96040-1dce-45f7-bf26-e81bc8d5b838" });
        }
    }
}
