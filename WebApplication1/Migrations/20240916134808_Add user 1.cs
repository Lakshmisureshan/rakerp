using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Adduser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba0aa86-1542-485f-a5a4-0cc7e7318ad5", "AQAAAAEAACcQAAAAEMOOI6mrNTRkqyA9qaMTr35u3RbB5wjDwfjqqarrJE27WlJlyNv5ZZxxzzhdbwoRrA==", "fc99cd7f-818d-4d85-ac85-95932277b827" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa0626f3-2b21-4aaa-b40e-9797b90eaf8d", "AQAAAAEAACcQAAAAEGu/oxIhZUP5rknAZRU83Pc2wMxKS2kGcoSszTQoFKdoDQ2UjnoLP38cYKcKB8tG0Q==", "07332b60-5be5-4758-a5fc-bf91b4efc3d1" });
        }
    }
}
