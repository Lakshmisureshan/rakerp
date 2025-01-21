using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addnullablekeyingrntracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "invid",
                table: "grntracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4cb33972-4181-4424-989a-a10223a3c9a0", "AQAAAAEAACcQAAAAEN0HAAi9IG2SCSDmKBN3aRSWso2az7zOMucF+Y7O7DsK7kss4kyQfuHdS4YwoFV8Rg==", "19b21248-d892-4227-b50f-4dbf9e94cda9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "invid",
                table: "grntracking",
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
                values: new object[] { "8b63c51c-0731-4f8b-8ba3-8a01c29f1149", "AQAAAAEAACcQAAAAEA36GA/soXvZO9O3k6chXmUmBQeMRosQvn8qX8jugS0hhPI1vNIQoyLRc5XxNi/ueg==", "f3027c44-80b3-4fd8-a7fe-8cfe759595ae" });
        }
    }
}
