using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsuppliertableemail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "SupplierContact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33b12601-71b4-4857-9c28-4212d56641ae", "AQAAAAEAACcQAAAAEHy/p2HQHxvkmBAAXJuqevySUmRzJNPfic/UA3rLaapwCQaR8pDItrbWW9DhO0xtkA==", "39f26cc0-1d9f-4e6f-9d21-27aaaeb0df05" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "SupplierContact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31407712-a247-4a3e-91e4-6254e981ec5f", "AQAAAAEAACcQAAAAEFDgmzIkfxgGWWOQq7ci7vN10JKYZr4ZYbx5JNLllDPOYwyEmaU+ijHI6Du5xdjU2A==", "dce7dc16-67d8-4380-bef4-d78c8dd2af1a" });
        }
    }
}
