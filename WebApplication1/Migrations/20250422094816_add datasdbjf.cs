using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatasdbjf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receiptamount",
                table: "receipt");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "067f0b69-12ff-4878-9fba-7400b426cc9e", "AQAAAAEAACcQAAAAEMNcOCshHdFwkOTanhMnA5t/PDKrUHmjMUbYIyjHiSq7JM9Caweul8o0ij48mdjHAw==", "e2aeeef3-b672-4f8b-89fc-01ea2f7d7765" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "receiptamount",
                table: "receipt",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b88adbcb-ff6b-4965-8d6a-2b3f06e8acb1", "AQAAAAEAACcQAAAAEBfS1y/smFXZuVLcO6azM+cwosa6TOiHNYBSmQ14glxEfSQbnWK7ep5h8PBXScUmNA==", "3e2770eb-ce2c-4f48-af56-063c2ad87b77" });
        }
    }
}
