using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addexpecteddeliverydate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "expecteddeliverydate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72d48a72-2239-4d5c-865e-b2ff81c5590d", "AQAAAAEAACcQAAAAEM5rigDaeadhO7K32xXiCrkycmiNO4uFOGlgYMjt4Mdko44tczukvVcq1gGD+XjyIA==", "fa6b36ce-1f89-4fb9-934b-e49034abcebc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expecteddeliverydate",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53652192-b514-4188-b2fd-246b8359bc67", "AQAAAAEAACcQAAAAEJsks3jnsrTNmU59hM4MBdyvOn5Z+ymYQ8rYYslWSFeDttaA5YsT6I0NcTSaawZYWg==", "3a4d3d2c-6600-4069-b4ad-447bee6a9bd5" });
        }
    }
}
