using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsubctegory1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    subcategoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subcategoryname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.subcategoryid);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "categoryid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dca8a144-2ced-4cbc-bfbe-d39f75b3d51a", "AQAAAAEAACcQAAAAECEoTHFumyWLA8iXy2Aetgr5PQYVu0gns9RKBy9MJFO4FqNvUQR6F56XgvT6AdqwDg==", "e209d0ce-dd1c-41ba-a0a5-b1af4739f4e6" });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_categoryid",
                table: "SubCategory",
                column: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4e39832-3f91-4669-b510-e73c2e4067e7", "AQAAAAEAACcQAAAAEJQpcpwJjAuodWHLiXfii03Ce7947gtKl8ZEmaEFlFpLrvphnOyV724sH6XkXzj8kQ==", "f42c4057-f198-499a-9a9a-23022a128d8e" });
        }
    }
}
