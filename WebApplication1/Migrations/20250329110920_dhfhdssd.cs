using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dhfhdssd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "qualitylevelid",
                table: "Job",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "projectcategoryid",
                table: "Job",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e967adb0-f2b7-4e7e-b6c6-760a3c3c9995", "AQAAAAEAACcQAAAAEMcp9qW10Uual4II+anRwyKk6bXlUKYa/Wqq0s/lnZkt8edcJwOGkdP1CEpAOuIX8g==", "3ff2e913-5bfe-4191-a549-e5a33ee01509" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "qualitylevelid",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "projectcategoryid",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc01035b-d9b7-415f-a468-595f07ca3906", "AQAAAAEAACcQAAAAEKwNihkEsO+hNLFRJSgjF9yu4lDphlx+HWK0jqNdiZ/VBDFRV+kCcjLEz/ePyI3OkQ==", "7dd33ce1-7ec4-43ee-bfed-17655fb49d34" });
        }
    }
}
