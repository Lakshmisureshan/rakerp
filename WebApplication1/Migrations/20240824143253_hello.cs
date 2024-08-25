using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class hello : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IsLDApplicable",
                columns: table => new
                {
                    ldid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLDApplicableName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsLDApplicable", x => x.ldid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f099f56-0f21-4998-8ca2-bcca6eceb7d6", "AQAAAAEAACcQAAAAEAwrBycXQUevjd9GIOVBs0HeZhgYw67qdvSoyOTBfpTDy9VOmhHZ9xreuvmS3GfAwQ==", "c9971d95-9b04-4465-a057-586d831c5b92" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IsLDApplicable");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd19386f-9cfa-47f6-b05d-98b66800d7ef", "AQAAAAEAACcQAAAAEAPaa9sl57k2QDTrmaUNPDPeu/NUTsKf2kwl3uHX6hQkL+L11nvkeAoi+ddCVhls0w==", "d0f25db4-fec9-4f43-ad6a-e543a5ecc515" });
        }
    }
}
