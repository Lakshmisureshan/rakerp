using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddataa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rtblid",
                table: "MIdetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c4b1a4f-596b-4ebb-84a8-4352bd95b415", "AQAAAAEAACcQAAAAEKfuEI9eGYuD5dur4gbtnqKj7FyK0irCe62SAjB0kBQ0PMXV2N7XOGtk4j0D78YKMQ==", "f719d79d-ca57-468d-b4f2-239312b889cb" });

            migrationBuilder.CreateIndex(
                name: "IX_MIdetails_rtblid",
                table: "MIdetails",
                column: "rtblid");

            migrationBuilder.AddForeignKey(
                name: "FK_MIdetails_ReceivedEntryDetails_rtblid",
                table: "MIdetails",
                column: "rtblid",
                principalTable: "ReceivedEntryDetails",
                principalColumn: "rtblid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MIdetails_ReceivedEntryDetails_rtblid",
                table: "MIdetails");

            migrationBuilder.DropIndex(
                name: "IX_MIdetails_rtblid",
                table: "MIdetails");

            migrationBuilder.DropColumn(
                name: "rtblid",
                table: "MIdetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43be0d6e-abc1-42e7-ac59-a2a45fef6965", "AQAAAAEAACcQAAAAEN7dceJvT5mEWpFSRPf9y2izS3RjiQlUjms9zTMiPwGvjRlOdoBIVRn6cCHVF9pijA==", "35102598-6827-4924-9b53-9e5ba097b9d0" });
        }
    }
}
