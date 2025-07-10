using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dsjbfbsdfds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyAddressLine1",
                table: "CompanyInfo",
                newName: "Companypobox");

            migrationBuilder.AddColumn<string>(
                name: "Companycountry",
                table: "CompanyInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a10fc98f-44e4-4808-90d4-00f1078eff74", "AQAAAAEAACcQAAAAEBM9BlvnFbdxAFUwWw2Cdyqb+nvfcoTnhQHsliOJZ7dieMcqoGkF2gf9gXM7tZLFTA==", "2c81544c-7d75-4507-863b-e039b99e5187" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyAddressLine2", "Companycountry", "Companypobox" },
                values: new object[] { "RAKEZ, Al Hamra, RAK", "UAE", "P.O Box 85652" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Companycountry",
                table: "CompanyInfo");

            migrationBuilder.RenameColumn(
                name: "Companypobox",
                table: "CompanyInfo",
                newName: "CompanyAddressLine1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b0641d5-76b6-4d59-b94c-72b77cd03e3a", "AQAAAAEAACcQAAAAEKwYvwr05y/r7mcb6lhJSVa07gjj9TfF6qam2v110HVO2NcJrQZfoY/Wt+r2PsT22g==", "1473e99e-63b3-43b9-a8d7-69ca63342846" });

            migrationBuilder.UpdateData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompanyAddressLine1", "CompanyAddressLine2" },
                values: new object[] { "P.O Box 85652, RAK-UAE", "Dengg.FZ-LLC" });
        }
    }
}
