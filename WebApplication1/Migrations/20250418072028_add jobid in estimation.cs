using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addjobidinestimation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "jobid",
                table: "FixedBudget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55264069-bdb7-4302-b380-d791c55909fa", "AQAAAAEAACcQAAAAEFYzHcAlPGJdgQg5SDRQZ20pWD967hxNDSaKtPNLNK7payYayMhW7Wzb6yBrUfmQwQ==", "94e1770e-730f-465a-915e-e0f32254c30e" });

            migrationBuilder.CreateIndex(
                name: "IX_FixedBudget_jobid",
                table: "FixedBudget",
                column: "jobid");

            migrationBuilder.AddForeignKey(
                name: "FK_FixedBudget_Job_jobid",
                table: "FixedBudget",
                column: "jobid",
                principalTable: "Job",
                principalColumn: "Jobid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FixedBudget_Job_jobid",
                table: "FixedBudget");

            migrationBuilder.DropIndex(
                name: "IX_FixedBudget_jobid",
                table: "FixedBudget");

            migrationBuilder.DropColumn(
                name: "jobid",
                table: "FixedBudget");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6725110f-4b2b-4b95-8f80-73c81b6682c1", "AQAAAAEAACcQAAAAED88vTMLP03RHnLkGmrnUTUkuBUAo6zT2WJ5tncOY0AaOQTr3tJCqvRT7A4nEsJT+g==", "614ce615-822f-4380-ae2f-fa3feae5433a" });
        }
    }
}
