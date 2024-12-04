using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addsupplieraddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "supplieraddress",
                table: "PO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df02e110-6d6f-49b0-a433-7b0ef2bbf3bb", "AQAAAAEAACcQAAAAEBSmCREu6NwJ4d9Ub0jp8vmJN+3LMXtwrkg/0iMLQjwUc1PZeeA0RbPhzCB8CmFa/Q==", "1c9360bf-1de3-4323-bf99-d52e5daaba97" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "supplieraddress",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc3ec4b8-a305-4b2a-b461-755418870263", "AQAAAAEAACcQAAAAEOeWhRUrhmLXbI/otJ9YiabY8pz7Nnlhsy4SFWp6m7nC0GuktPR7U5MNLJBVuhH7LQ==", "0f13a47c-4644-49e5-bd50-9b46d240b6db" });
        }
    }
}
