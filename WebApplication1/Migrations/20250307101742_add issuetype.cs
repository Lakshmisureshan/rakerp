using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "issuetype",
                table: "IssueNoteheader",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4259fa44-211c-4a50-939f-7fc4f61b0007", "AQAAAAEAACcQAAAAELe/XTGyLTDGc2VE1VLfnkoQTENn/+xCp+8Q1O5+JADTjhvbLAivo2tV4GhOYC7L1A==", "d352eb5c-2b90-485d-acce-679417fd46d9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "issuetype",
                table: "IssueNoteheader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42310d30-d91a-4565-918f-e69d4f2b5518", "AQAAAAEAACcQAAAAEKocBOOBUjvMDl2y1mH8YOfDiWsOfcq6kZsdQL9fWennivQLivTbchngUTiIfAPVeA==", "28d00519-a9eb-4f7c-b32c-94127990fe4a" });
        }
    }
}
