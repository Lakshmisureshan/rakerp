using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatassdfbsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ordervaluewithvat",
                table: "Job",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "vatpercent",
                table: "Job",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b410d883-f01c-4ea3-96d4-97d2042262b7", "AQAAAAEAACcQAAAAEDkUBEtCZlArgMvbdFk9lHSow2TgR+R4BCyI+7FLDZT63XEBQ7Ik38Gi9MQKZ9ZDIQ==", "034a46ea-0b4b-480c-a9a2-83f70513dfbc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ordervaluewithvat",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "vatpercent",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7062c990-561a-4e6b-b6f2-b6d1f3c5324b", "AQAAAAEAACcQAAAAEG5S12Ns3SOBxLoNqkv6z5eVuK4cN0C5zRu8GoaweR2Peuxe3EUEpxctCN9lvN841g==", "6bd3d8f2-6660-4d39-94f0-647b8b91ba79" });
        }
    }
}
