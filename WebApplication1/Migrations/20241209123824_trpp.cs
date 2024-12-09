using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class trpp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add primary key constraint to issueref column
            migrationBuilder.Sql(@"
                ALTER TABLE [IssueNoteheader]
                ADD CONSTRAINT PK_IssueNoteheader PRIMARY KEY (issueref);
            ");

            // Update data for the user in AspNetUsers table
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42527613-f2c8-44df-915c-b29dee36d94f", "AQAAAAEAACcQAAAAEJ8OgM1EIVbv6NCz3m/r9FG2x7hqGtGSE+pOjbEf/A9CcnxW1I/H5Nh8VRlJerP8tQ==", "aac81e22-833e-46fb-94a4-04046057244a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the primary key constraint from issueref column
            migrationBuilder.Sql(@"
                ALTER TABLE [IssueNoteheader]
                DROP CONSTRAINT PK_IssueNoteheader;
            ");

            // Revert the user data changes in AspNetUsers table
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e844a9b0-9f23-4245-91b2-a4368298d39e", "AQAAAAEAACcQAAAAEIWxNXuC5P/dF/brDsXm9ujQHiCDrMKD0KF/1F6nhoJJu//oeHtjCKBpSrfnfs4Wpg==", "02496d7c-944e-4dae-8a7c-4719a87fc7e8" });
        }
    }
}