using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addreceiptamount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "receiptamount",
                table: "receipt");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65ecb364-6877-4f43-a85c-014e4e06dfb3", "AQAAAAEAACcQAAAAEEnRbNQp979w9mhICI5hl/c/b6ftdKWz6pJNr0J/2z2hpwli4hbEMCb0T7QdnnYhSQ==", "dda56a49-53aa-42a7-ac53-e19c2d4484d1" });
        }
    }
}
