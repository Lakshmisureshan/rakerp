using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddProjectCatgeory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectCategory",
                columns: table => new
                {
                    projectcategoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectcategoryname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategory", x => x.projectcategoryid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77f973b2-62a7-413a-9753-1c792cf82220", "AQAAAAEAACcQAAAAEPQGKHDywOl0gSd+859qAYXp3U+pYl2WBNLRJ1yP2x/MYgF4Z/2kkWZ9BThKkrYrZw==", "8fc8cac3-d325-43bc-9c77-5dfe0d934e00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCategory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbe6378c-e224-4f2a-8fb8-f7b41fa94b52", "AQAAAAEAACcQAAAAEBtKOLrTryGgr1wMz3OGwlk1u9D5SBCezOBk9/pGRXNPRekGIfjeHZWequJNpTgdiA==", "461f007b-53b7-4a73-af13-fad5019c837a" });
        }
    }
}
