using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class postatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "postatus",
                columns: table => new
                {
                    postatusid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postatusname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postatus", x => x.postatusid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5edadcb-daf8-4184-906f-3e05c83d3ae4", "AQAAAAEAACcQAAAAEFrLEyYduCU8H9tad4mDiQ6U3Rx8Y3jU1PFPbh614Bp1znI+k89skvW4qTK0WFWeLA==", "1bec4a91-dbf6-48a6-a992-81cb37f67b37" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postatus");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "51af3ade-a151-480c-8781-09c2dfc9280d", "AQAAAAEAACcQAAAAEMOmY+Cnjw/DfXPHT0HmCvNQVOYbTT5oQl2FbGFy+GCM+hGrtAjCy093KAPZ5eE83A==", "de93d356-98e0-462e-883d-537d612d4a71" });
        }
    }
}
