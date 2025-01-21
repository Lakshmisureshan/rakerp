using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcurrencyidanduomidinissuereturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ircurrencyid",
                table: "Issuereturndetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iruomid",
                table: "Issuereturndetails",
                type: "int",
                nullable: false,
                defaultValue: 0);






            migrationBuilder.Sql(@"
              UPDATE Issuereturndetails
SET iruomid = IssuedetailsfromStock.issueuomid,

ircurrencyid =IssuedetailsfromStock.issuecurrencyid
FROM IssuedetailsfromStock
WHERE Issuereturndetails.issuedetailtblid = IssuedetailsfromStock.issuedetailid;
            ");























            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b773b166-2027-4223-bd79-3961ad305601", "AQAAAAEAACcQAAAAEJpOHPi41w8E0ohLAJEnUswoFZrXRypk9ZDRFgzPUs2ixBVDn0J01W8ExCKDKzZasA==", "da0495d3-4cb6-42aa-aef8-ffcc990dec7a" });

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_ircurrencyid",
                table: "Issuereturndetails",
                column: "ircurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_iruomid",
                table: "Issuereturndetails",
                column: "iruomid");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuereturndetails_Currency_ircurrencyid",
                table: "Issuereturndetails",
                column: "ircurrencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuereturndetails_UOM_iruomid",
                table: "Issuereturndetails",
                column: "iruomid",
                principalTable: "UOM",
                principalColumn: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issuereturndetails_Currency_ircurrencyid",
                table: "Issuereturndetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuereturndetails_UOM_iruomid",
                table: "Issuereturndetails");

            migrationBuilder.DropIndex(
                name: "IX_Issuereturndetails_ircurrencyid",
                table: "Issuereturndetails");

            migrationBuilder.DropIndex(
                name: "IX_Issuereturndetails_iruomid",
                table: "Issuereturndetails");

            migrationBuilder.DropColumn(
                name: "ircurrencyid",
                table: "Issuereturndetails");

            migrationBuilder.DropColumn(
                name: "iruomid",
                table: "Issuereturndetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d5fa21d-5686-4a4d-8304-1c0a0a12345d", "AQAAAAEAACcQAAAAEMVkibYmSYHN4Zyf8qG7c7YdSmbKxRFI78Ce/d2yb49Sjmwo2vyt5gxc9Gk/tf0Ojw==", "c186eb4f-ac3c-4317-a9eb-2e255c797821" });
        }
    }
}
