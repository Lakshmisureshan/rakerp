using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addnullabletoqandprojectcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc01035b-d9b7-415f-a468-595f07ca3906", "AQAAAAEAACcQAAAAEKwNihkEsO+hNLFRJSgjF9yu4lDphlx+HWK0jqNdiZ/VBDFRV+kCcjLEz/ePyI3OkQ==", "7dd33ce1-7ec4-43ee-bfed-17655fb49d34" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "376fdee2-96e6-4e24-849b-e7a9df6b5ad1", "AQAAAAEAACcQAAAAEI3i1kmF1CUlOepPZCaH1lr2GI0mUkZmVlpghzwAyICrEN/aRf3o5F2Dkpkti4NCWw==", "fff2d68c-8e6e-4433-8a95-0403bc9c8499" });
        }
    }
}
