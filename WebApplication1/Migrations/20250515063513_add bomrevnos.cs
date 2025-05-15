using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addbomrevnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "bomjobrevno4",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bomjobrevno5",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bomjobrevno6",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bomjobstatusid4",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bomjobstatusid5",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bomjobstatusid6",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9dc5ff47-b598-4e00-bcc5-6f5fe11b6dbf", "AQAAAAEAACcQAAAAEOIyOci5XyC0ozjlxtwiJfHzN9VHD08DTcn4Tg8B3htRWz08Wwdxl1Szdpfm8lFkSQ==", "562d01c1-d97f-4b46-a304-529d7c2351df" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bomjobrevno4",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "bomjobrevno5",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "bomjobrevno6",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "bomjobstatusid4",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "bomjobstatusid5",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "bomjobstatusid6",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "578fc4bd-d74a-4cf9-bb47-09d7cb1c79ea", "AQAAAAEAACcQAAAAECVT4K7V61C28ZvMHSUsKmYdRjl0RPoafv3rtQ+hYzBwsr7WGgUtzkvsxuHBlek7GQ==", "4c34c82a-d80e-48d6-8455-e2cb1db8456f" });
        }
    }
}
