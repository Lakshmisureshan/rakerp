using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcontactdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e4c77e1-fb36-49b7-ab99-2919ae5cbd65", "AQAAAAEAACcQAAAAEJaQ5sJBXRIGSghpdpCv/RgOxmC27/bWvON28Xz2t2NAP8GuPP6ZWLl2ghUhad6law==", "4620f270-85b9-4ef7-918e-80f9887c67de" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "79d6ce0f-c9dc-469a-b961-e10f0d30380e", "AQAAAAEAACcQAAAAEMFrmLSw0E3NhfIJtgRnq76t6tHJQ5rEBJPP0gi7wCTCOXJiwam8eUd+db5/e4Z/xw==", "3bd58126-0c45-49c0-9834-4d7cf94ba97d" });
        }
    }
}
