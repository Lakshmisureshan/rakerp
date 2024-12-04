using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsuppliertrnno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "suppliertrnno",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f994404c-3601-43ff-9cec-1822e895d9bb", "AQAAAAEAACcQAAAAENQz0CWvQUlDdI+E80/k2c6cGHKMWn+8CcsJDdv4DVffmlHgWehQDgTjhB/vhkuASg==", "f6beba44-5f37-4546-9950-34294aeb8674" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "suppliertrnno",
                table: "Supplier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6571ef91-4f86-43f1-8fad-f4fdbc798bd2", "AQAAAAEAACcQAAAAEJln2Q8U8BUqY8IVzDMQI4wZVdjfjtGseYUHTCZhIKgNAxJu12o4WjwoFB1zM1F7/w==", "ab10deef-d00e-4e84-81e9-536ec5ff1fe0" });
        }
    }
}
