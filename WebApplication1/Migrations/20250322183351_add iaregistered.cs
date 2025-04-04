using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addiaregistered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isregistered",
                table: "Invoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3458dee5-470a-4eab-b567-fa6646ebc9f6", "AQAAAAEAACcQAAAAEHUJrJ3hl7ANEpTbawgRRswuAo6UTIgztbj8p5tUZn0sDmvKR/CyNpNxaffUFz8YZA==", "c9e37102-3d7c-4734-acc9-18093991ce92" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isregistered",
                table: "Invoice");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "973dbf2e-4a13-467a-8f56-ebc3fe289fdf", "AQAAAAEAACcQAAAAELIhRJ1SD/uUTg9sXhrI/4YrRPw9+DrlUvqhpI/3gEoHqoVLB1xLLASwPzDeEjWc6A==", "3a1c03ec-2a1d-4554-9d41-c00e9d23cea1" });
        }
    }
}
