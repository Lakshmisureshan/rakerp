using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcategoryinproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    budgetheaderid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryid);
                    table.ForeignKey(
                        name: "FK_Category_BudgettHeader_budgetheaderid",
                        column: x => x.budgetheaderid,
                        principalTable: "BudgettHeader",
                        principalColumn: "budgetheaderid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e65f3b4c-2f71-4472-9638-e23fe9bb4c0e", "AQAAAAEAACcQAAAAEB7gccJE00NLhk7uVQy039dSWro9xrKI4XYgQMf0nijKhF2MzeHuo1VHw0fuFUYv2A==", "de5c63ad-817f-4d4e-aea1-5eb2764e6232" });

            migrationBuilder.CreateIndex(
                name: "IX_Category_budgetheaderid",
                table: "Category",
                column: "budgetheaderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a09b1071-82d5-4e45-881d-e290562a1947", "AQAAAAEAACcQAAAAEOSVCmfPevjSkjvu0t8Vp9heWArZ28beGHqoTiXz+8BJeGTcYlbjSMiUEdClJT9pEw==", "1e40e2e2-591a-41e8-b846-bd3ef12c4262" });
        }
    }
}
