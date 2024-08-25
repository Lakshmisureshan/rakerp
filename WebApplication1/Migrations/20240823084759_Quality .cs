using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Quality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityLevel",
                columns: table => new
                {
                    qualitylevelid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qualitylevelname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityLevel", x => x.qualitylevelid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7080d66b-f0b6-46cc-ac71-8037b81a2679", "AQAAAAEAACcQAAAAEGiF60VeFZyJIZLJ1Unak0r3nDgkcYOgu/19RLniNc1w9fy4RWnyS/K3EFUU/nK4mQ==", "40c97337-36e8-49a3-a712-7b12708a1f0c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityLevel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77f973b2-62a7-413a-9753-1c792cf82220", "AQAAAAEAACcQAAAAEPQGKHDywOl0gSd+859qAYXp3U+pYl2WBNLRJ1yP2x/MYgF4Z/2kkWZ9BThKkrYrZw==", "8fc8cac3-d325-43bc-9c77-5dfe0d934e00" });
        }
    }
}
