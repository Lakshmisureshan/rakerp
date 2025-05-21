using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcompanycode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "companycode",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa4ea7d7-e0b2-4997-8109-0eec21c3927f", "AQAAAAEAACcQAAAAEG+ce2M3f4VSdvuBnBiyrd2tVwIdvPN3D1qj9ZYUfda7vAGan9DiFXtOBTN4Q6B+qw==", "e154e7da-9b2d-49bc-8a60-9d9967dd2441" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companycode",
                table: "Company");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01265240-9698-45d9-acfa-330eff6744d9", "AQAAAAEAACcQAAAAEJsVkZZd4qYHQRAfO2XrMQ2GyRXq+j5a28xAjs3L5ytC52LTu3mcPPXtgQ5w5Ym5+g==", "32493e25-55b4-4f11-9085-2d076cc3c4e9" });
        }
    }
}
