using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class additembudgetheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "itembudgetheaderid",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1be071a-8219-4ba6-8ba9-ce3b71b16eee", "AQAAAAEAACcQAAAAELYxRwHQ0bH2+wykstG02pG+hOMFmlMsIAKBY7xEE1CmWQbaBp8wI2GqPVLpl3i6Ow==", "bde058bf-9ac5-4ce4-84eb-dd5a7053f42f" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_itembudgetheaderid",
                table: "Product",
                column: "itembudgetheaderid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_BudgettHeader_itembudgetheaderid",
                table: "Product",
                column: "itembudgetheaderid",
                principalTable: "BudgettHeader",
                principalColumn: "budgetheaderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_BudgettHeader_itembudgetheaderid",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_itembudgetheaderid",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "itembudgetheaderid",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c95b50c9-49a9-4dc4-a4ce-aea31f8c42de", "AQAAAAEAACcQAAAAEOS2Vtl6R7cbxo3MEUcfkojq5sv2RUXO/6/hUf/TubAqvXSaCDrzqOjLFOjEzdvrlw==", "4691341d-9397-49b4-bccc-da32d75c37ff" });
        }
    }
}
