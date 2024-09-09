using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bomjobstatusid",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8149c54-4e7c-4c03-ac95-df35bc23f066", "AQAAAAEAACcQAAAAEM4/tug8gS/1PMtTF0EJ5vqK0Ew2zRE481WfwUmYN3at+3rp1U3HgWY5wJ0IjxVQPw==", "4551dbed-f5a7-494d-aff7-6cf9a8d86d8a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bomjobstatusid",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "998f3729-42fb-4d8a-a39b-3554439088ba", "AQAAAAEAACcQAAAAEP+4LgGxbl8WxJgQ9JHvV4N9fFgke8EVN4s7ektfyOsYAFH0DXJ31pgM1h5ef3gMTg==", "8dfaf9fd-120c-4e69-beb5-664afa7ab196" });
        }
    }
}
