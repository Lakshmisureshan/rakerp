using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adduomandcurrencyinissuedetails123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "issuecurrencyid",
                table: "IssuedetailsfromStock",
                type: "int",
                nullable: false,
                defaultValue: 0);


       






            migrationBuilder.AddColumn<int>(
                name: "issueuomid",
                table: "IssuedetailsfromStock",
                type: "int",
                nullable: false,
                defaultValue: 0);
















            migrationBuilder.Sql(@"
              UPDATE IssuedetailsfromStock
SET issueuomid = Inventoryreservation.uomid,

issuecurrencyid =Inventoryreservation.invrcurrencyid
FROM Inventoryreservation
WHERE Inventoryreservation.rid = IssuedetailsfromStock.rid;
            ");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "339f96e2-37c3-4668-865f-62fb62adbe8c", "AQAAAAEAACcQAAAAEMOkAikw9lWpFa2eJL+UTFrIV5ep2wfpNbBimKKdZ9yOic6R0BmTyr4whlcVFqkjdA==", "086d886f-6084-4f98-9732-c5c63e2f0998" });

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_issuecurrencyid",
                table: "IssuedetailsfromStock",
                column: "issuecurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_issueuomid",
                table: "IssuedetailsfromStock",
                column: "issueuomid");

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedetailsfromStock_Currency_issuecurrencyid",
                table: "IssuedetailsfromStock",
                column: "issuecurrencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_IssuedetailsfromStock_UOM_issueuomid",
                table: "IssuedetailsfromStock",
                column: "issueuomid",
                principalTable: "UOM",
                principalColumn: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IssuedetailsfromStock_Currency_issuecurrencyid",
                table: "IssuedetailsfromStock");

            migrationBuilder.DropForeignKey(
                name: "FK_IssuedetailsfromStock_UOM_issueuomid",
                table: "IssuedetailsfromStock");

            migrationBuilder.DropIndex(
                name: "IX_IssuedetailsfromStock_issuecurrencyid",
                table: "IssuedetailsfromStock");

            migrationBuilder.DropIndex(
                name: "IX_IssuedetailsfromStock_issueuomid",
                table: "IssuedetailsfromStock");

            migrationBuilder.DropColumn(
                name: "issuecurrencyid",
                table: "IssuedetailsfromStock");

            migrationBuilder.DropColumn(
                name: "issueuomid",
                table: "IssuedetailsfromStock");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc37d960-a9f5-492b-a49f-c0d163136b71", "AQAAAAEAACcQAAAAEFXvecNysWaZltjDBxi918CmqSAiHLFLU9FXOqEcANzI1RFaT/jHVqcSyQJ6hj3hTA==", "66814c52-9ade-483b-84ff-575fc589fccf" });
        }
    }
}
