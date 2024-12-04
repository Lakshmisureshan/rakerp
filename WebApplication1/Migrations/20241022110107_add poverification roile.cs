using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpoverificationroile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e648847-b462-464d-8e1e-aa20a7947bef", "5e648847-b462-464d-8e1e-aa20a7947bef", "POVerification", "POVERIFICATION" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad889903-bd84-4c74-b635-9a9633fde305", "AQAAAAEAACcQAAAAEGNh/JpsIPSj+7iI+mBsFZtx9A8NeIurnuSg2cbKEJ+Uv/JtXbJDlAKd1Wx6J/euKw==", "0a7c770e-2874-4b3d-a548-51c6047b7582" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5e648847-b462-464d-8e1e-aa20a7947bef", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5e648847-b462-464d-8e1e-aa20a7947bef", "356ff228-0e5f-436a-9ac5-2d760b997dd5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e648847-b462-464d-8e1e-aa20a7947bef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06bbb1f0-c47f-4708-a4f4-68511f12bad5", "AQAAAAEAACcQAAAAEHb+/9IQFk+KiI4dG7INGj0Aqz1iiyLyQ3t/VniYnfkljGqrMvWDOIutm2ow3s8nqQ==", "7aa335dc-9572-436f-93a1-9f8b62f860ad" });
        }
    }
}
