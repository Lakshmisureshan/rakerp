using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class reorderqtyreorderlevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "reorderlevel",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "reorderqty",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fcbb250-2567-48b5-9e4c-9e61615f9473", "AQAAAAEAACcQAAAAEMZDcagY+f+Ai737jjPlrvfYivdhTm78cheFca9sUsE3zKuXNozXcBs3N2JsYVCAmw==", "7e1b1d7b-7828-4ba1-a115-09f41ce3624f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reorderlevel",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "reorderqty",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fd8ded8-f514-4260-bb6a-0adfa3fdcf54", "AQAAAAEAACcQAAAAENHdpI4S6Am2ZY3qkza+Q7J9d6Z2UwVlT/iT276f0GPH/s0Xb7DOPY5SRcaURJus3Q==", "a74c8e29-83d4-4316-b239-7efc6d21a792" });
        }
    }
}
