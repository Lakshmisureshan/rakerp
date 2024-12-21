using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatas890 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2f8e715-2c63-4b8c-bbc6-6920a318c275", "AQAAAAEAACcQAAAAEMsoAtl3kAc229bIF47Q7Zh/kaUCF1xMgH5Vr9EVaRkXFjzmGQn9+MYYNUajnvn2+w==", "f6e46e20-1b61-43e2-a6a7-399de352022b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63738141-4789-436e-8955-3735afa60d51", "AQAAAAEAACcQAAAAEG1knOawPHopFHS7pfb2qql4WQ2KH/jrqsfss9jZY0b/7eQOEqFFgaTBi3/kiIzCDQ==", "122c8a5f-d02d-4f0b-8a17-cff9f7764f38" });
        }
    }
}
