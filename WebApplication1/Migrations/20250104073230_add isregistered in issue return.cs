using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addisregisteredinissuereturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isregistered",
                table: "Issuereturn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d5362f-1ded-455f-8d92-11a676100d90", "AQAAAAEAACcQAAAAEAi4+pvGqVmsJfSPV744CnDApUkpgTVgORtSf2R05AiiaKp3cxCfzGu5p1Eko4P0EA==", "ebb776bf-b63f-4978-b80f-97ecf9fd9e50" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isregistered",
                table: "Issuereturn");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb066f7a-f148-49ab-beef-d64ec5a84d5c", "AQAAAAEAACcQAAAAEFa5I/+2P+VjLtPmOu9SiezMurr6l8kFj8N44YhfLwByz8YkgYkOEs5oes2r/GJllg==", "cc137cac-c2e0-48c0-af37-409913cf9ae8" });
        }
    }
}
