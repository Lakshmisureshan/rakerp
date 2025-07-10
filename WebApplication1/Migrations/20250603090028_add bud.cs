using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addbud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "budgetheaderid",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // ✅ Set default value for existing records
            migrationBuilder.Sql("UPDATE PO SET budgetheaderid = 1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[]
                {
                    "0124c475-ed51-4a0f-8c9a-1819a3098824",
                    "AQAAAAEAACcQAAAAEN12K63gZSv5pfniMLbthfv4qCViZx1tc5l4Fb67jhD2fIaeJWDdMAJZsUAlOKfMqA==",
                    "2261b867-dc8e-4b4f-978b-ab5f3c6ecb79"
                });

            migrationBuilder.CreateIndex(
                name: "IX_PO_budgetheaderid",
                table: "PO",
                column: "budgetheaderid");

            migrationBuilder.AddForeignKey(
                name: "FK_PO_BudgettHeader_budgetheaderid",
                table: "PO",
                column: "budgetheaderid",
                principalTable: "BudgettHeader",
                principalColumn: "budgetheaderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PO_BudgettHeader_budgetheaderid",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_PO_budgetheaderid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "budgetheaderid",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[]
                {
                    "a86ab625-fe6c-4cd5-a7e7-eabe37ef7111",
                    "AQAAAAEAACcQAAAAED5so1cIvcuBNTUe2KCuTBhc8BCQPUaJD6gAZ4aptaL+L8znhQNuxA1W/VlQq1TMgA==",
                    "664c86a7-d8ff-45a0-ba4e-ff280624b939"
                });
        }
    }
}
