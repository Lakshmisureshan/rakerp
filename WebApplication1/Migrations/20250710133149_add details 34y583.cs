using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddetails34y583 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "expecteddeliverydate",
                table: "Job",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9009696-3546-4b76-98b8-6dfae439310b", "AQAAAAEAACcQAAAAEPUsLHPP0qkyjdAeNa/qVxnyAbdDLUR8Z+QCAEPESgZzcpsnRE+vvlMFt8fJnN4QHA==", "470bd013-ece9-492c-ac11-4d92eb0632e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "expecteddeliverydate",
                table: "Job",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b410d883-f01c-4ea3-96d4-97d2042262b7", "AQAAAAEAACcQAAAAEDkUBEtCZlArgMvbdFk9lHSow2TgR+R4BCyI+7FLDZT63XEBQ7Ik38Gi9MQKZ9ZDIQ==", "034a46ea-0b4b-480c-a9a2-83f70513dfbc" });
        }
    }
}
