using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatandvhdfv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "issuereturntype",
                table: "Issuereturn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbc36dbe-c2f1-45d9-9e28-647a83589b26", "AQAAAAEAACcQAAAAEOgS/MHqTQ2mh1v/iQKj0+ske1PrKDmRf7UYDVWXhvADzhHd3v/9Ir0DJqBmCI2PGA==", "ad43b5b1-c4d5-4945-854b-a4d98c36391d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "issuereturntype",
                table: "Issuereturn");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae179dac-bc0e-4f4b-ae82-ec1223270d58", "AQAAAAEAACcQAAAAEGkTXplan29erfft2gmk9WjumWS+z077ryj4bMcDxYabkPsDwDp7rCNS+HY9KcO3jg==", "73e99d34-10a5-4cc2-8a8e-63f2b7387de2" });
        }
    }
}
