using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    supplierid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    suppliername = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.supplierid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a07a3243-14cf-4d41-a56f-0efee107ef9d", "AQAAAAEAACcQAAAAEJfuNHozC8zqpm/sMvh7BNACJhRYr/2bnElorhigc1Rh6eI+yfzh1e4Qw77ff98d/Q==", "d4b5a7f7-8c34-4073-b0f0-9a8958e2d4ad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aad37553-69b4-4dbb-92af-5c01d7111775", "AQAAAAEAACcQAAAAENN7UcUnioiz2HiEJLzePkHRQWO3joeJmWW23PJ1IFtSdNcDx4Eo3uYeRNj+7o+kUg==", "d50039e8-382a-4a5f-b6fc-f141d8e82110" });
        }
    }
}
