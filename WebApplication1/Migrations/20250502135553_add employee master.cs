using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addemployeemaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53867036-198f-4813-985b-16b91dfbfee6", "AQAAAAEAACcQAAAAEEIQ0ZrI5dVVObZgPP1Ey9ztnvaqygUMuzxDz9n+36VFF8kkBg3hYk+a9gSRujJGKA==", "c81f36e0-f4af-488c-9ea6-f3cb6ce238bd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66608367-a0c5-4a63-87f2-8cd59770dc1c", "AQAAAAEAACcQAAAAENvhXKhX6U33aWgPEa+POizcPh/Y7Nd4WMOlmanFZLmReUh7NhqCBMSLFEiU0XyNbQ==", "25913d4d-44ea-4786-b166-8f0bfb9c0042" });
        }
    }
}
