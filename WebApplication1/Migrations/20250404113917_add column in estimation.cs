using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcolumninestimation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "isconvertedtobom",
                table: "estimation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af8f6281-a854-40e1-9d72-01572dc2e28a", "AQAAAAEAACcQAAAAENo4rgmReSVppEb/w0UyiJ4cHb1OyPeMNuIYAs6aSP79WeBWjN+fJo2Bg0Cna9M/Jg==", "7ac5fdf7-285c-456d-8b74-551101ca3256" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isconvertedtobom",
                table: "estimation");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96a8c5bc-f489-49d9-99fc-d6cc580a2332", "AQAAAAEAACcQAAAAEMWWxi48TKmTf0/MdSjW80d0V4otYfjZclje9CEx3zBGQqYV1I1NbvhS0yVTmOL7vg==", "64f40e8d-bbb8-4902-a565-fbc1bbb921e4" });
        }
    }
}
