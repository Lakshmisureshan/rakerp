using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addbomrev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bomjobrevno2",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bomjobstatusid2",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f770bf2b-824e-4ca3-afa0-f5177712e132", "AQAAAAEAACcQAAAAENIwecoJODV/2ieoYUvWXeQvXafH9/AyB7TQ47F/6jpLkTujUZu+3L9zaOeXjyLCuA==", "8860bd9f-deb6-4944-973d-41ca078bd726" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bomjobrevno2",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "bomjobstatusid2",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9c1369d-264e-45e9-b0bc-3a06e7c15be9", "AQAAAAEAACcQAAAAEAWB0cQn7ImoamzHL+00fFkxtzMisI7SB53TYsL0Yj0+V/77RgE2rNIsSbVgR0vfvg==", "37d26fff-ab18-4855-9d28-7ac4c9da96ae" });
        }
    }
}
