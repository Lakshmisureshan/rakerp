using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpounitpriceingrn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "pounitprice",
                table: "GRNDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b19a35d2-fa93-4cf5-b9cd-b084e44ddb7f", "AQAAAAEAACcQAAAAENxHPUt2IPsIZesqzhOxRl0YlOMKmiydbNbX6VHIJtM6pc1jP+v3Z7zHLA+CkxjUCQ==", "b79eff7c-db16-42b2-bff3-b88929487b40" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pounitprice",
                table: "GRNDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01f07202-4815-4445-b722-699d0bd7a204", "AQAAAAEAACcQAAAAEJcPg8IfEdq5yGCyd0s5Lmp4SjiT/mBZLIVlnxwEWU75i9TwXoBy8z+Rl70yGMZtOQ==", "abc5a1b1-139e-4042-ac7c-050f317c6230" });
        }
    }
}
