using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class productionstages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductionStages",
                columns: table => new
                {
                    prostageid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productionstagename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionStages", x => x.prostageid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed85da3-1143-4a13-bd08-5132a0f6a3c2", "AQAAAAEAACcQAAAAEPs6iMQD79dtjNqUcegJUksod/FROgT8iS+dGDI0ndGoAk5KD3laMXT78gMtJTYd7g==", "bda1f806-34a9-463e-b03c-17881f4c8a17" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductionStages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75734347-3396-4b79-b907-82c59fef9d9f", "AQAAAAEAACcQAAAAEBA8Vy4Ay76T9+zIjMK0KFxgwTG5hmLUC8LelUj5YiW66NEPDl+/IrUHBy6GcJx6Mw==", "e5bfb50d-aab0-44f2-aee7-e96b06e64544" });
        }
    }
}
