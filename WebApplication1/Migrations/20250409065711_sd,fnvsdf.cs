using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class sdfnvsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "jobstageid",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"
                UPDATE Job 
                SET jobstageid = 1
            ");


            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a12ffcab-924b-4969-b84e-4f9847c6e87f", "AQAAAAEAACcQAAAAECwy1mVi1wPbclvnU5IzcnlIljbRYAScwkOQl887l10f2ekwQJn2CAUa/xKMFGJN6Q==", "cff86d59-cdd0-42df-ad45-cf22d21a27ca" });

            migrationBuilder.CreateIndex(
                name: "IX_Job_jobstageid",
                table: "Job",
                column: "jobstageid");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobStage_jobstageid",
                table: "Job",
                column: "jobstageid",
                principalTable: "JobStage",
                principalColumn: "jobstageid");




        





        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobStage_jobstageid",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_jobstageid",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "jobstageid",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d4702f6-25fe-48cd-ab1b-052150bfc5e7", "AQAAAAEAACcQAAAAEObDujfu4oiPPL7K+GzOhvGd3TynIl5w6VbE4ozRaa9R4z8D9uHVJQOMov9WHJ+GiQ==", "1622f60a-bfb4-439d-b816-fd920178f4f9" });
        }
    }
}
