using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bomrevno",
                table: "Bom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "daa9d89a-5cc1-4228-a637-fb142c8bb270", "AQAAAAEAACcQAAAAEJmhCkqnys+XuvkqGTPg+0mhAWnf9QPEf+YF0qK1OrGP3Id8jXYKdtfXFemqJmd4ew==", "bad960c3-09b1-4888-8e0c-4d0503098689" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bomrevno",
                table: "Bom");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82692a6a-4e9a-47a3-8d77-864fb3da8eaf", "AQAAAAEAACcQAAAAEGmohBqkmwy3ETrBPYbJMkYRwbjGRJCNwy2JKwUl0qTnWcuThu0RYziZTpoIHHf8xQ==", "760f511b-1ef7-4f96-b61a-b63d55f476b8" });
        }
    }
}
