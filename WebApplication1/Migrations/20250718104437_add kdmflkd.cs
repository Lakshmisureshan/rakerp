using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addkdmflkd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "Issuetracking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "issuereturntracking",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1cfad31-d322-4e5f-8150-dd99cc770e5f", "AQAAAAEAACcQAAAAEGZlVTLVA3h43oVa8JlcHYQ++wAxiyUvYkcFjYRDRSGvhEbw5iWtEC8CA148VO+bQw==", "4ec6514d-fddd-4460-bf6f-f5315ebf621f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location",
                table: "Issuetracking");

            migrationBuilder.DropColumn(
                name: "location",
                table: "issuereturntracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58890f63-8353-4490-9590-56584d9045e1", "AQAAAAEAACcQAAAAEHfesB5yQdtTXMJ3NZ1vsAtZ2+SiMfRIBS18mh04ABH2PxvqA5sM8/G2wRq7XoM1gQ==", "a18d29c5-9c1c-48e9-9a29-9ecda70b0e5d" });
        }
    }
}
