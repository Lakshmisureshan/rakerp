using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addprcreatedby : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "prcreatedbyid",
                table: "PR",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4e39832-3f91-4669-b510-e73c2e4067e7", "AQAAAAEAACcQAAAAEJQpcpwJjAuodWHLiXfii03Ce7947gtKl8ZEmaEFlFpLrvphnOyV724sH6XkXzj8kQ==", "f42c4057-f198-499a-9a9a-23022a128d8e" });

            migrationBuilder.CreateIndex(
                name: "IX_PR_prcreatedbyid",
                table: "PR",
                column: "prcreatedbyid");

            migrationBuilder.AddForeignKey(
                name: "FK_PR_AspNetUsers_prcreatedbyid",
                table: "PR",
                column: "prcreatedbyid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PR_AspNetUsers_prcreatedbyid",
                table: "PR");

            migrationBuilder.DropIndex(
                name: "IX_PR_prcreatedbyid",
                table: "PR");

            migrationBuilder.DropColumn(
                name: "prcreatedbyid",
                table: "PR");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8c03e95-4f40-439e-8f1a-d61fc3bb2be2", "AQAAAAEAACcQAAAAEA6QcRjyLOur0yQ2NZ9zqFXVqTcZvgl8zLnb8Car7lEhhEbuwAK+exwjPN5gXWswLw==", "aa30ace0-ff8c-4005-9699-e0cd853246b6" });
        }
    }
}
