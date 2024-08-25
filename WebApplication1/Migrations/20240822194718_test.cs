using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManufacturingBay",
                columns: table => new
                {
                    BayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingBay", x => x.BayId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbe6378c-e224-4f2a-8fb8-f7b41fa94b52", "AQAAAAEAACcQAAAAEBtKOLrTryGgr1wMz3OGwlk1u9D5SBCezOBk9/pGRXNPRekGIfjeHZWequJNpTgdiA==", "461f007b-53b7-4a73-af13-fad5019c837a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturingBay");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "328bc4e0-ed1f-45d9-9b16-d90b66e11c7d", "AQAAAAEAACcQAAAAEF+FHRfNQ2YGLmipdfC75nJLE00WSc9ylChOjpvHCBlH8IHvT4zIZjGz7PxmEd221g==", "289b9f06-fdb6-400d-acec-866662cf4e8b" });
        }
    }
}
