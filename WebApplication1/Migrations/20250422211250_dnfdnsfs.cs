using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dnfdnsfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "totalreceivedinbasecurrency",
                table: "Job",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3c10eb9-da98-4bd8-864e-8529f5e80433", "AQAAAAEAACcQAAAAEFQOIJQIdEFpDJNIPCK9S1CYYwVUVPu6SREMkfetxvyjdXBjPbY+TwZjY7xR33/FoA==", "b5f56b21-30cf-45bc-aaf7-c32c5446d831" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalreceivedinbasecurrency",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "067f0b69-12ff-4878-9fba-7400b426cc9e", "AQAAAAEAACcQAAAAEMNcOCshHdFwkOTanhMnA5t/PDKrUHmjMUbYIyjHiSq7JM9Caweul8o0ij48mdjHAw==", "e2aeeef3-b672-4f8b-89fc-01ea2f7d7765" });
        }
    }
}
