using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class dfgfd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d0a8b3f-f1a1-4461-8102-00b01a3d16a7", "AQAAAAEAACcQAAAAEMpvQ7R01Gy5vKLY2exvWnlYoLhQJSWI7sveSfaBb5QwIJDhZwsbgAcqV2stsv8uSA==", "cd74a4be-378a-4a93-8e3e-34a81f227142" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dbf70549-2217-4ac8-bb74-7adb6a1b8cf6", "AQAAAAEAACcQAAAAEMVNfNR8G+ugZ70yK3STQdPebJmei1/nq23IWQh4qQTQltRNaTA6VLjO5b5gwZZmVQ==", "8fda55fd-a36a-4a05-a6d0-1ccbf850dbdc" });
        }
    }
}
