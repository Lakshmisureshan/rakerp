using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class asvdfhsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dec5f63-f060-4866-abec-21d8e8403f6a", "AQAAAAEAACcQAAAAELBuYk8kCm89OaXzHJv1XL1aLzexeq0fMdEKms0IRMN4PoSVluHUxC3hUZOWuVn1gQ==", "0d7a5440-9afa-4984-bd81-6861a96baaa2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0d07314-6b3c-44d4-9045-af87db627ee7", "AQAAAAEAACcQAAAAEHMJeRBumbR+i0TSEce/ib4fdFagFswWc4wWKNmkqx6hq9Gv5G9lR1ziIzQNRPiPgA==", "ad942da9-af5e-499e-acb7-71b583b95739" });
        }
    }
}
