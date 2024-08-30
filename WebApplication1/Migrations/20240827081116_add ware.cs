using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addware : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    wId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warehousename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.wId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "75734347-3396-4b79-b907-82c59fef9d9f", "AQAAAAEAACcQAAAAEBA8Vy4Ay76T9+zIjMK0KFxgwTG5hmLUC8LelUj5YiW66NEPDl+/IrUHBy6GcJx6Mw==", "e5bfb50d-aab0-44f2-aee7-e96b06e64544" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8ee986c-4d84-4f4c-803c-557bd4c98cd8", "AQAAAAEAACcQAAAAEOT12UdWVY/KYwQUYoeCvdnjrWt2c7yDkVGOJ2L845BOc8DuSK95bSEn2G8EfmdNlg==", "81e34395-7627-4cc2-9de8-ff6762ca7052" });
        }
    }
}
