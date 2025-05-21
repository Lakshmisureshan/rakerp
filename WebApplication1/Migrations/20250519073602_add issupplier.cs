using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "issupplier",
                table: "Employeemaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b19a37d7-4541-44b2-be21-593e45f54f81", "AQAAAAEAACcQAAAAEEr+UeemCsprvX/9DYtmpQ6urfyOROw9q/nnZVW3oqy7ogS9lMVOObndpKN+nOkEYg==", "7c6de369-de2c-44dc-9334-ce57291624a6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "issupplier",
                table: "Employeemaster");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57a036b3-93e5-46b1-9966-5b24bcb094e3", "AQAAAAEAACcQAAAAEPw+82UEjfGeMIlzEihis48sCtrKKM0IW+BSzSlO8kQUmwycQraWCSp2/8/kpsbQ0g==", "a17912d5-faef-4704-9b89-43333dceb3c2" });
        }
    }
}
