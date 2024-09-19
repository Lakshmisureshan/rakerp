using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addenduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "enduserid",
                table: "Job",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e45bc224-0c3e-4228-a124-9d576b36012e", "AQAAAAEAACcQAAAAEG1mR7FSoZFcH7Cb71tKTpaHQAhjn0B974XFcgBH6h7kvVlH/GSN57huIQDmNYJ/Xg==", "5b316647-ae72-40e6-a646-a032bab16e7b" });

            migrationBuilder.CreateIndex(
                name: "IX_Job_enduserid",
                table: "Job",
                column: "enduserid");

            migrationBuilder.AddForeignKey(
                name: "FK_Job_Customer_enduserid",
                table: "Job",
                column: "enduserid",
                principalTable: "Customer",
                principalColumn: "customerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Job_Customer_enduserid",
                table: "Job");

            migrationBuilder.DropIndex(
                name: "IX_Job_enduserid",
                table: "Job");

            migrationBuilder.DropColumn(
                name: "enduserid",
                table: "Job");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba0aa86-1542-485f-a5a4-0cc7e7318ad5", "AQAAAAEAACcQAAAAEMOOI6mrNTRkqyA9qaMTr35u3RbB5wjDwfjqqarrJE27WlJlyNv5ZZxxzzhdbwoRrA==", "fc99cd7f-818d-4d85-ac85-95932277b827" });
        }
    }
}
