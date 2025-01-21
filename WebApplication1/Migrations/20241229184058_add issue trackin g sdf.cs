using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuetrackingsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grntracking_Inventory_invid",
                table: "grntracking");

            migrationBuilder.DropForeignKey(
                name: "FK_Issuetracking_Inventory_invid",
                table: "Issuetracking");

            migrationBuilder.DropIndex(
                name: "IX_Issuetracking_invid",
                table: "Issuetracking");

            migrationBuilder.DropIndex(
                name: "IX_grntracking_invid",
                table: "grntracking");

            migrationBuilder.AlterColumn<int>(
                name: "invid",
                table: "grntracking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9140dae8-aa79-447b-94d2-565047d22bb8", "AQAAAAEAACcQAAAAEHmbC+1yxlCVWiuEVOu8xvnSTTAKNZETRUoLWlalKQ+P1lzWheVlTuU72zcG6PE4DQ==", "f87f9a3d-6cd7-4623-88a2-a7550d99f5f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "invid",
                table: "grntracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2e5676c-821e-411e-93a0-8ef48b0ec213", "AQAAAAEAACcQAAAAEFMicNIFYdw9t5DJ7dnpWkTqjS//GOTS2K9yZ85G6WIJOegxpi3U5kevruMKz0G61w==", "52166a4a-5cbf-4d6f-b091-e8c2edb94772" });

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_invid",
                table: "Issuetracking",
                column: "invid");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_invid",
                table: "grntracking",
                column: "invid");

            migrationBuilder.AddForeignKey(
                name: "FK_grntracking_Inventory_invid",
                table: "grntracking",
                column: "invid",
                principalTable: "Inventory",
                principalColumn: "invid");

            migrationBuilder.AddForeignKey(
                name: "FK_Issuetracking_Inventory_invid",
                table: "Issuetracking",
                column: "invid",
                principalTable: "Inventory",
                principalColumn: "invid");
        }
    }
}
