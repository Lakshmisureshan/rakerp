using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class fhdfjg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c64184a6-a148-4206-8e3c-a2c9effa9085", "AQAAAAEAACcQAAAAECiM9ikycMl90Lbr7CfaQQcmBkR/xnoIKyYhXjd0wqurBs3Be0l6EaWK0V517J8Mbg==", "c146c0c7-0483-49f2-aabc-c0bb26515680" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e8f5a73-f374-4400-a3fe-5e937b6e5bde", "AQAAAAEAACcQAAAAEPeKrKsNAmaK2Im4WStM7h0uUUqeuz/nv/66Gat0YLeceCbn2gAah8HNSPz5kU0I3w==", "46600571-2d0e-44e8-ad0b-2ab0d7747152" });
        }
    }
}
