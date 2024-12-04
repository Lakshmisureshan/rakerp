using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addpochangespostatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "postatusid",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a178a06c-c678-49dd-be15-750e0a14457a", "AQAAAAEAACcQAAAAEKaWEDMKHGyMl4RLi23rKpxDtwND0P/rQrJ4F0m78FoboXp5U12oyJ1bIZAnMU588g==", "ff69f529-68e5-4322-8c4d-eb6caf20ba0f" });

            migrationBuilder.CreateIndex(
                name: "IX_PO_postatusid",
                table: "PO",
                column: "postatusid");

            migrationBuilder.AddForeignKey(
                name: "FK_PO_postatus_postatusid",
                table: "PO",
                column: "postatusid",
                principalTable: "postatus",
                principalColumn: "postatusid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PO_postatus_postatusid",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_PO_postatusid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "postatusid",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5edadcb-daf8-4184-906f-3e05c83d3ae4", "AQAAAAEAACcQAAAAEFrLEyYduCU8H9tad4mDiQ6U3Rx8Y3jU1PFPbh614Bp1znI+k89skvW4qTK0WFWeLA==", "1bec4a91-dbf6-48a6-a992-81cb37f67b37" });
        }
    }
}
