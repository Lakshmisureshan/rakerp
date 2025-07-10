using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class sdfjbdsfsdfjs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f192bd9e-01c6-4eee-b99a-4736032097e1", "AQAAAAEAACcQAAAAEJrdAGdS8Rw/aPuMU8ooWUM1eLmazGNVMFeaOAUt7PIKAf/L2qTPAe54vVxBrs3hfQ==", "5263bdf1-5c4f-46cb-8a95-89cffc6fdf3d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "17226b04-b1a6-463b-a0b5-5fc558ba2c41", "AQAAAAEAACcQAAAAEB3DKFPkuusouI8lN097E/9LeOyvYNVRF+SVCJW4MFg0lTIJJNGYigkBoEfn987mHQ==", "849cdc78-d2ad-417d-8521-58dbcb8151d1" });
        }
    }
}
