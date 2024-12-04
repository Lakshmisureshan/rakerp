using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addpodeliveryterms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Qtnref",
                table: "PO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71ff2a34-26f7-4593-9483-6f7787138fd2", "AQAAAAEAACcQAAAAEJ3PQCpEPFwP52tq0X68QbdufJb9iRIOtH2+9G8UTOllFcF9QslkjPdC4DjDOMYzHQ==", "64cba825-8291-4898-b679-1d996ec3ccc4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qtnref",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df02e110-6d6f-49b0-a433-7b0ef2bbf3bb", "AQAAAAEAACcQAAAAEBSmCREu6NwJ4d9Ub0jp8vmJN+3LMXtwrkg/0iMLQjwUc1PZeeA0RbPhzCB8CmFa/Q==", "1c9360bf-1de3-4323-bf99-d52e5daaba97" });
        }
    }
}
