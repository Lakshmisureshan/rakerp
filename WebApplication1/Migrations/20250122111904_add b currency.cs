using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addbcurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseCurrency",
                columns: table => new
                {
                    basecurrencyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    basecurrency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCurrency", x => x.basecurrencyid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bf944ff-598c-4e3b-820b-d56c5708bedc", "AQAAAAEAACcQAAAAEErVpYJsCRSI1isUIoaiDZWLStDkLvULRuqGBCq4SIg9mbcMPrHEStjIj5LgEwvenw==", "930e31f0-2e70-4aa9-9976-f281604336c3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseCurrency");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4ca4b91-562f-4733-9e84-85508bca1dfe", "AQAAAAEAACcQAAAAEHvfpODCUloyNIYt/Ik8nY6QgdBfg7D8yuPZXqo8gB45vBI/tmMvkI0yQ7z+r/USZA==", "495f70d1-a59c-4182-a064-91fd703fd950" });
        }
    }
}
