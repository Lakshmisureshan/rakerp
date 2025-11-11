using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class uu99 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // *** Step 1: Add EnquiryStatusId column as NULLABLE (Crucial for existing data) ***
            migrationBuilder.AddColumn<int>(
                name: "EnquiryStatusId",
                table: "Enquiry", // Assuming your table is named "Enquiry"
                type: "int",
                nullable: true); // Start as nullable to allow the UPDATE in the next step

            // *** Step 2: Update ALL existing rows to set the status to 1 ***
            // This ensures all pre-existing records point to the valid 'New Enquiry' status.
            migrationBuilder.Sql("UPDATE Enquiry SET EnquiryStatusId = 1");

            // *** Step 3: Change the column to NOT NULL and set default for future inserts ***
            // This guarantees data integrity moving forward.
            migrationBuilder.AlterColumn<int>(
                name: "EnquiryStatusId",
                table: "Enquiry",
                type: "int",
                nullable: false, // Now non-nullable
                defaultValue: 1); // Set default for future inserts

            // *** Step 4: Add the Foreign Key constraint ***
            // This enforces the relationship with the existing Enquirystatus table.
            migrationBuilder.AddForeignKey(
                name: "FK_Enquiry_Enquirystatus_EnquiryStatusId",
                table: "Enquiry",
                column: "EnquiryStatusId",
                principalTable: "Enquirystatus",
                principalColumn: "enqstatusid",
                onDelete: ReferentialAction.Restrict);

            // (ASP.NET Identity User Update Data)
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efc375a2-71b0-4824-a7d4-f32410160fa6", "AQAAAAEAACcQAAAAEEVgwEcdofb8hYoec5ZuoJguvdXwHpI27iZVu2YcDGMPWDd9pjuzKq8vE/rBzu1BVQ==", "725a2ad1-b733-4af1-9584-31e00601232f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the Foreign Key first
            migrationBuilder.DropForeignKey(
                name: "FK_Enquiry_Enquirystatus_EnquiryStatusId",
                table: "Enquiry");

            // Remove the column
            migrationBuilder.DropColumn(
                name: "EnquiryStatusId",
                table: "Enquiry");

            // NOTE: We don't drop the Enquirystatus table here since it was created in a previous migration.

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9d616b3-183e-47bc-8ad8-8a8cc95d8fa1", "AQAAAAEAACcQAAAAEEKP1bCjjp398TZlR1HErEKNXHoXkbvgr2x9KL6nIOJjw+z4ZVf+yaadnUNS+H0n5A==", "fcdc4629-33a3-4285-89eb-55d9e783fe4b" });
        }
    }
}