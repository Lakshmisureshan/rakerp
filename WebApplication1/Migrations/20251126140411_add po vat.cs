using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpovat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "taxamount",
                table: "PO",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "vatpercent",
                table: "PO",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "620ccbfe-2d78-4522-be03-5b19dbdee7cd", "AQAAAAEAACcQAAAAEGnl4YkXFA6lGSNkoaqMaQiuggYHgJi6m3l1j5bfmtlNW8lWtDwlhqlgo//NlpEweQ==", "4ca5dd8d-a729-4837-8eea-a21018917d67" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "taxamount",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "vatpercent",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68b2e706-bfac-43a6-a5d0-e8d01ed67fdd", "AQAAAAEAACcQAAAAEGyDs+CJe8oRB/9GtmzRmoamEXHfqhoJTpmg6fR1E85mft/0PI6B0cQSrIE2D+6YDQ==", "0d3d9fc2-1f29-464b-a5dd-9767ebb8599b" });
        }
    }
}
