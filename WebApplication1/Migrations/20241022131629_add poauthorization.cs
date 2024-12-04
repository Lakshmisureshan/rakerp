using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpoauthorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "333559dc-c729-403c-a80e-77250b8a0592", "333559dc-c729-403c-a80e-77250b8a0592", "POAuthorization", "POAUTHORIZATION" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9c65826-055f-4742-ae90-80337defccd9", "AQAAAAEAACcQAAAAEHn/px3C4kA0xDZ+LLcK5l/pGISm2kmD5U1eX4vevIeTGqAtEECWLgz2Y8NiQnnsCw==", "47351ef9-fbb7-410d-ad75-6903cbacc06c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "333559dc-c729-403c-a80e-77250b8a0592", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "333559dc-c729-403c-a80e-77250b8a0592", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "333559dc-c729-403c-a80e-77250b8a0592");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad889903-bd84-4c74-b635-9a9633fde305", "AQAAAAEAACcQAAAAEGNh/JpsIPSj+7iI+mBsFZtx9A8NeIurnuSg2cbKEJ+Uv/JtXbJDlAKd1Wx6J/euKw==", "0a7c770e-2874-4b3d-a548-51c6047b7582" });
        }
    }
}
