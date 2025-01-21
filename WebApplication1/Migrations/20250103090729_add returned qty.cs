using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addreturnedqty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "returnedqty",
                table: "IssuedetailsfromStock",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3a8de9d-fb76-4c5d-b71a-f50356429b5d", "AQAAAAEAACcQAAAAEGtwNxDCqsXESScgeBnbg1Pq/iJevWkcHsoOQ1jdHFh80qQH4RO0ahzWyTxld+hEqQ==", "a8145e6f-0f7f-413b-b634-1263e9b85dd1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "returnedqty",
                table: "IssuedetailsfromStock");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a54d106a-844e-4853-ac42-373b407e2f4b", "AQAAAAEAACcQAAAAEDt/E6h/7mNChYwtR4rxFV0IeVOsaOHeZU71ytBJOwEQrvXcBftgc5qiMfGJWWOgNw==", "0e255ae8-0964-4f64-906d-7ebe87167305" });
        }
    }
}
