using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class test12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bomjobrevno",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "998f3729-42fb-4d8a-a39b-3554439088ba", "AQAAAAEAACcQAAAAEP+4LgGxbl8WxJgQ9JHvV4N9fFgke8EVN4s7ektfyOsYAFH0DXJ31pgM1h5ef3gMTg==", "8dfaf9fd-120c-4e69-beb5-664afa7ab196" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bomjobrevno",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daa9d89a-5cc1-4228-a637-fb142c8bb270", "AQAAAAEAACcQAAAAEJmhCkqnys+XuvkqGTPg+0mhAWnf9QPEf+YF0qK1OrGP3Id8jXYKdtfXFemqJmd4ew==", "bad960c3-09b1-4888-8e0c-4d0503098689" });
        }
    }
}
