using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dbfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9747c6ef-5c3b-4850-aa9d-63001452f2ee", "AQAAAAEAACcQAAAAEHjTkpuVYC4dYnCaWw8JB31fyWOzgwdiSkYNhpr8g3zZE9AHqyj36x+KkNkdpHHTuA==", "2d2da2a0-7744-492e-a783-1cd5cd462e2e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbc36dbe-c2f1-45d9-9e28-647a83589b26", "AQAAAAEAACcQAAAAEOgS/MHqTQ2mh1v/iQKj0+ske1PrKDmRf7UYDVWXhvADzhHd3v/9Ir0DJqBmCI2PGA==", "ad43b5b1-c4d5-4945-854b-a4d98c36391d" });
        }
    }
}
