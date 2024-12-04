using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Adddbsdfjsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PRPO",
                table: "PRPO");

            migrationBuilder.AlterColumn<decimal>(
                name: "pounitprice",
                table: "Purchasedetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "poquantity",
                table: "Purchasedetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "prpotblid",
                table: "PRPO",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRPO",
                table: "PRPO",
                column: "prpotblid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15d93113-575e-4c02-95df-725f7b56897c", "AQAAAAEAACcQAAAAEElPfZ4YY5NO6E4LAt1TPL+LhnvrA7NCe9Q4MzP8VI1lzoKqDsbFRSSKNg5vbmX7QA==", "37bcf466-be80-477d-9aec-b380401209f1" });

            migrationBuilder.CreateIndex(
                name: "IX_PRPO_Purchasedetailspotblid",
                table: "PRPO",
                column: "Purchasedetailspotblid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PRPO",
                table: "PRPO");

            migrationBuilder.DropIndex(
                name: "IX_PRPO_Purchasedetailspotblid",
                table: "PRPO");

            migrationBuilder.DropColumn(
                name: "prpotblid",
                table: "PRPO");

            migrationBuilder.AlterColumn<double>(
                name: "pounitprice",
                table: "Purchasedetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "poquantity",
                table: "Purchasedetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PRPO",
                table: "PRPO",
                columns: new[] { "Purchasedetailspotblid", "prdetailsprtblid" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1c56a208-7de9-43b4-878a-97e376488476", "AQAAAAEAACcQAAAAEIPESHjUPSENA6w53KuyDSr16lSU+mUKjcsVl2gxQveMCEtU+9LF5DBlQL+YHfUpAQ==", "6faadb01-fb15-42f2-afe1-0ff6edb5a622" });
        }
    }
}
