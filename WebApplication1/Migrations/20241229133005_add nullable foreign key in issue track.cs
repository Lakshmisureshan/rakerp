using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addnullableforeignkeyinissuetrack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "invid",
                table: "Issuetracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b63c51c-0731-4f8b-8ba3-8a01c29f1149", "AQAAAAEAACcQAAAAEA36GA/soXvZO9O3k6chXmUmBQeMRosQvn8qX8jugS0hhPI1vNIQoyLRc5XxNi/ueg==", "f3027c44-80b3-4fd8-a7fe-8cfe759595ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "invid",
                table: "Issuetracking",
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
                values: new object[] { "5676ebb0-1362-4587-8dda-3befa3757e0b", "AQAAAAEAACcQAAAAEJIUAjtywdhjhsvX7bnw2vL4utDz7WRhYhz83BOeeoOVBuMoD18LoWL+PxNf3Yl2wg==", "a604df87-046c-4d07-8c83-dc69aea4f1cf" });
        }
    }
}
