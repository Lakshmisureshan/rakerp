using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class enduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ef29232-9305-4d51-93fc-24d58b35cd68", "AQAAAAEAACcQAAAAELo37CVHmf9be5G7JBJ8cAKO8VbFuODLRH2rRrQQ+fSVtJ35ZwqW6QajF+XUbJuYkA==", "478d9e07-3850-46cf-b07c-4630f01c7dac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e45bc224-0c3e-4228-a124-9d576b36012e", "AQAAAAEAACcQAAAAEG1mR7FSoZFcH7Cb71tKTpaHQAhjn0B974XFcgBH6h7kvVlH/GSN57huIQDmNYJ/Xg==", "5b316647-ae72-40e6-a646-a032bab16e7b" });
        }
    }
}
