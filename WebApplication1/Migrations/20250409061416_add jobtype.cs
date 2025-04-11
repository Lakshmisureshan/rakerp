using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addjobtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b396d57e-0281-4547-a299-7f41579e90d4", "AQAAAAEAACcQAAAAEAk+Ll1Qu3ks6TO6xRGVsPgc0I15fdwuKCeH/NJjCMs5kdKEKDtj0PHhOQaWY4LvfA==", "64328a42-abd1-426b-ad9c-31a34f0851e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3780c34a-c6fa-4884-86a4-1a0595624d30", "AQAAAAEAACcQAAAAEMtn9Pn/H9ywf0vT3JfH0Ed/LPH6N4/xDsjJcn+FA18M96Opfk7gH609ox7RpNmG8A==", "098a0cf5-9aa3-4403-ab5b-3ca1e9c6dd92" });
        }
    }
}
