using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class test123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    currencyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currencyname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exchangerate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.currencyid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd19386f-9cfa-47f6-b05d-98b66800d7ef", "AQAAAAEAACcQAAAAEAPaa9sl57k2QDTrmaUNPDPeu/NUTsKf2kwl3uHX6hQkL+L11nvkeAoi+ddCVhls0w==", "d0f25db4-fec9-4f43-ad6a-e543a5ecc515" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f45bfda4-6fae-451f-9456-a6e10823dbaa", "AQAAAAEAACcQAAAAEDznFt4Q03wHeqOf6BPaSRubV1UlCeojavMNgqctei8ZqrPrvcrzbKFHyC+Su/JjvQ==", "6f44a38c-ba6e-4be4-b7fb-9c87581dd6aa" });
        }
    }
}
