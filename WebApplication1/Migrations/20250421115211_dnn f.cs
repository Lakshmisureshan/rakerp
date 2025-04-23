using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dnnf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbb2c0cb-b5bf-4ac8-8198-55c281ebf51c", "AQAAAAEAACcQAAAAEOPtgROQ2ScE024quDQe79EXGw8gSRSJZ+6N5a0VxdCRzJgAmDIFvbzoZcl5LlzKRg==", "753f53dc-5215-4a83-be68-6c74666fc0a1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "160ea288-f3fb-4bb7-9e62-dd658fa9a2af", "AQAAAAEAACcQAAAAEOjP7JJl2anS3BVqRTpTLIX9fCgj3so4X+Cx6eyzmevLoc/cMck8LgepBhjR5h1Ihw==", "b8e52189-89cb-44af-bb18-7557a58726da" });
        }
    }
}
