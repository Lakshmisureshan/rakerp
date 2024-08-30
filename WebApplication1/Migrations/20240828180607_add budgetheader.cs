using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addbudgetheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgettHeader",
                columns: table => new
                {
                    budgetheaderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    budgetheadername = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgettHeader", x => x.budgetheaderid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4168f2bb-1edb-4d14-8ee0-807bded9f03d", "AQAAAAEAACcQAAAAEFKpduIi8V/q0il/QkFN0daqDeKDcRtXkqvkp2Ygnxg5CCYHzvdH8HOuZVUwrS7N+Q==", "75c57ee4-651d-425e-b031-27d75dee59f1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgettHeader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed85da3-1143-4a13-bd08-5132a0f6a3c2", "AQAAAAEAACcQAAAAEPs6iMQD79dtjNqUcegJUksod/FROgT8iS+dGDI0ndGoAk5KD3laMXT78gMtJTYd7g==", "bda1f806-34a9-463e-b03c-17881f4c8a17" });
        }
    }
}
