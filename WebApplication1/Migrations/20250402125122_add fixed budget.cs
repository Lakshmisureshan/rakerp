using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addfixedbudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FixedBudget",
                columns: table => new
                {
                    fixedbudgetid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    budgetId = table.Column<int>(type: "int", nullable: false),
                    fixedamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    revision = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedBudget", x => x.fixedbudgetid);
                    table.ForeignKey(
                        name: "FK_FixedBudget_BudgettHeader_budgetId",
                        column: x => x.budgetId,
                        principalTable: "BudgettHeader",
                        principalColumn: "budgetheaderid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f51655d-668b-48ed-ac59-d95690c19957", "AQAAAAEAACcQAAAAEO1hcOwtmVNRpW35ahKtqjEP1vbMSv35AWw8c+QsNkCaDuouzYiaFHcMdzi+HijRqg==", "f3791a64-ace9-40cd-ba82-bb9daec6b167" });

            migrationBuilder.CreateIndex(
                name: "IX_FixedBudget_budgetId",
                table: "FixedBudget",
                column: "budgetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FixedBudget");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56ded367-124b-4080-a136-681d5db1f20f", "AQAAAAEAACcQAAAAEJyxW3UTiJcv1ORWzWMyV6nNjkvnD9fQRAvH/WnfXbewm5tF7SOq15kgq++1NCyY5g==", "c126a095-6e68-4070-9f01-5d02b1256217" });
        }
    }
}
