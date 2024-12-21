using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuenoteisregistered : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isregistered",
                table: "IssueNoteheader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a09b1071-82d5-4e45-881d-e290562a1947", "AQAAAAEAACcQAAAAEOSVCmfPevjSkjvu0t8Vp9heWArZ28beGHqoTiXz+8BJeGTcYlbjSMiUEdClJT9pEw==", "1e40e2e2-591a-41e8-b846-bd3ef12c4262" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isregistered",
                table: "IssueNoteheader");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5abb8be0-d970-4824-af31-ca5ab68cbf43", "AQAAAAEAACcQAAAAED7O/etcbqCnBEPTSnWVLScCweqd7DfZ2PwrrVp3c0LJfH1Eyn9MFEuE5MoPv/wZfA==", "a566aeb9-06b0-404d-96c3-3e0c577dec46" });
        }
    }
}
