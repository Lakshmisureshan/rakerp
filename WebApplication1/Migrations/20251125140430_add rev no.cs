using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addrevno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "revno",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b03beb1b-ea12-4cbf-b00f-94d11727678a", "AQAAAAEAACcQAAAAEG2w2NkrTtbpW7vkLOo4KbiHiacEh589ZqPeWmOWHAKhIY26hf21zS9fOwN7wzJ2Ow==", "aa67e4d9-40ad-4eef-8d64-9ae1c8d8897a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "revno",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33b12601-71b4-4857-9c28-4212d56641ae", "AQAAAAEAACcQAAAAEHy/p2HQHxvkmBAAXJuqevySUmRzJNPfic/UA3rLaapwCQaR8pDItrbWW9DhO0xtkA==", "39f26cc0-1d9f-4e6f-9d21-27aaaeb0df05" });
        }
    }
}
