using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addacceptedrejectedhold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "acceptedqty",
                table: "ReceivedEntryDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "holdqty",
                table: "ReceivedEntryDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "rejectedqty",
                table: "ReceivedEntryDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16c87ea8-64c5-4dbe-aefa-e7146bff7fe2", "AQAAAAEAACcQAAAAEDsXH53wbuXDJN+PC/z6eqn3YC6GqE1XeVNlj/rKUufugzWQARgfoL/bw/obmykYpg==", "e49ceb4a-e691-4c37-abc4-ddfb81562009" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "acceptedqty",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropColumn(
                name: "holdqty",
                table: "ReceivedEntryDetails");

            migrationBuilder.DropColumn(
                name: "rejectedqty",
                table: "ReceivedEntryDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5440739c-e1c8-4638-90bc-7302974f8289", "AQAAAAEAACcQAAAAEI14WRH904cLetYwi59g05LnS2yXXropyoPQH/FOqBWTQuGZtYJLF6YXYzyNsev/7A==", "05932362-c4a3-44e9-8c71-1279cf09e3c6" });
        }
    }
}
