using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addjobtypefgm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the foreign key constraint that references the 'jobtypeid' column
            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobType_jobtypeid",
                table: "Job");

            // Step 2: Drop the primary key constraint (if applicable) on 'jobtypeid'
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobType",
                table: "JobType");

            // Step 3: Drop the 'jobtypeid' column
            migrationBuilder.DropColumn(
                name: "jobtypeid",
                table: "JobType");

            // Step 4: Add a new column with the desired IDENTITY property
            migrationBuilder.AddColumn<int>(
                name: "NewJobTypeId",  // New column name
                table: "JobType",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");  // Set IDENTITY property

            // Step 5: Rename the new column to match the old column's name
            migrationBuilder.RenameColumn(
                name: "NewJobTypeId",
                table: "JobType",
                newName: "jobtypeid");

            // Step 6: Recreate the primary key constraint on 'jobtypeid'
            migrationBuilder.AddPrimaryKey(
                name: "PK_JobType",
                table: "JobType",
                column: "jobtypeid");

            // Step 7: Recreate the foreign key constraint that references 'jobtypeid'
            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobType_jobtypeid",
                table: "Job",
                column: "jobtypeid",
                principalTable: "JobType",
                principalColumn: "jobtypeid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the foreign key constraint referencing 'jobtypeid'
            migrationBuilder.DropForeignKey(
                name: "FK_Job_JobType_jobtypeid",
                table: "Job");

            // Step 2: Drop the primary key constraint on 'jobtypeid'
            migrationBuilder.DropPrimaryKey(
                name: "PK_JobType",
                table: "JobType");

            // Step 3: Drop the 'jobtypeid' column
            migrationBuilder.DropColumn(
                name: "jobtypeid",
                table: "JobType");

            // Step 4: Recreate the old column 'jobtypeid' with the original IDENTITY property
            migrationBuilder.AddColumn<int>(
                name: "jobtypeid",
                table: "JobType",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Step 5: Recreate the primary key constraint on 'jobtypeid'
            migrationBuilder.AddPrimaryKey(
                name: "PK_JobType",
                table: "JobType",
                column: "jobtypeid");

            // Step 6: Recreate the foreign key constraint that references 'jobtypeid'
            migrationBuilder.AddForeignKey(
                name: "FK_Job_JobType_jobtypeid",
                table: "Job",
                column: "jobtypeid",
                principalTable: "JobType",
                principalColumn: "jobtypeid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}