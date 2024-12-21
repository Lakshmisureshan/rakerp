using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuedtoinissuenoteheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "issuedto",
                table: "IssueNoteheader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5abb8be0-d970-4824-af31-ca5ab68cbf43", "AQAAAAEAACcQAAAAED7O/etcbqCnBEPTSnWVLScCweqd7DfZ2PwrrVp3c0LJfH1Eyn9MFEuE5MoPv/wZfA==", "a566aeb9-06b0-404d-96c3-3e0c577dec46" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "issuedto",
                table: "IssueNoteheader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3241079f-2051-4d9b-ae54-63708802b864", "AQAAAAEAACcQAAAAEJznPvHhUXaBKw5JE+DKUsTewEU5KkL2ZXRgmkCF7lhmEdVboVs4uakz7xLtT+ofrA==", "3e711b0d-ee69-4b07-8c37-1253db70291a" });
        }
    }
}
