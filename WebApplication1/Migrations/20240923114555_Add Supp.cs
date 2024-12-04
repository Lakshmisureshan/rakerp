using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddSupp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "supplierid",
                table: "PO",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc3ec4b8-a305-4b2a-b461-755418870263", "AQAAAAEAACcQAAAAEOeWhRUrhmLXbI/otJ9YiabY8pz7Nnlhsy4SFWp6m7nC0GuktPR7U5MNLJBVuhH7LQ==", "0f13a47c-4644-49e5-bd50-9b46d240b6db" });

            migrationBuilder.CreateIndex(
                name: "IX_PO_supplierid",
                table: "PO",
                column: "supplierid");

            migrationBuilder.AddForeignKey(
                name: "FK_PO_Supplier_supplierid",
                table: "PO",
                column: "supplierid",
                principalTable: "Supplier",
                principalColumn: "supplierid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PO_Supplier_supplierid",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_PO_supplierid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "supplierid",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a07a3243-14cf-4d41-a56f-0efee107ef9d", "AQAAAAEAACcQAAAAEJfuNHozC8zqpm/sMvh7BNACJhRYr/2bnElorhigc1Rh6eI+yfzh1e4Qw77ff98d/Q==", "d4b5a7f7-8c34-4073-b0f0-9a8958e2d4ad" });
        }
    }
}
