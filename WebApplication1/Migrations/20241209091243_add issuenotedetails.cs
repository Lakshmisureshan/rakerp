using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addissuenotedetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop any foreign key constraints that depend on the issueref column
            migrationBuilder.Sql(@"
        DECLARE @fkName NVARCHAR(128);
        SELECT @fkName = fk.name
        FROM sys.foreign_keys fk
        INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
        INNER JOIN sys.columns c ON c.object_id = fkc.parent_object_id AND c.column_id = fkc.parent_column_id
        WHERE fk.parent_object_id = OBJECT_ID(N'IssueNoteheader') AND c.name = 'issueref';
        IF @fkName IS NOT NULL
        BEGIN
            EXEC(N'ALTER TABLE [IssueNoteheader] DROP CONSTRAINT [' + @fkName + ']');
        END
    ");

            // Step 2: Drop the primary key constraint if it depends on the issueref column
            migrationBuilder.Sql(@"
        DECLARE @pkName NVARCHAR(128);
        SELECT @pkName = pk.name
        FROM sys.key_constraints pk
        INNER JOIN sys.index_columns ic ON pk.parent_object_id = ic.object_id AND pk.unique_index_id = ic.index_id
        INNER JOIN sys.columns c ON ic.object_id = c.object_id AND c.column_id = c.column_id
        WHERE pk.parent_object_id = OBJECT_ID(N'IssueNoteheader') AND c.name = 'issueref';
        IF @pkName IS NOT NULL
        BEGIN
            EXEC(N'ALTER TABLE [IssueNoteheader] DROP CONSTRAINT [' + @pkName + ']');
        END
    ");

            // Step 3: Add a new temporary column without the IDENTITY property
            migrationBuilder.AddColumn<int>(
                name: "new_issueref",
                table: "IssueNoteheader",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Step 4: Copy data from the old column to the new column
            migrationBuilder.Sql("UPDATE IssueNoteheader SET new_issueref = issueref");

            // Step 5: Drop default constraint on the old column (if it exists)
            migrationBuilder.Sql(@"
        DECLARE @var0 sysname;
        SELECT @var0 = [d].[name]
        FROM [sys].[default_constraints] [d]
        INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
        WHERE ([d].[parent_object_id] = OBJECT_ID(N'IssueNoteheader') AND [c].[name] = N'issueref');
        IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [IssueNoteheader] DROP CONSTRAINT [' + @var0 + '];');
    ");

            // Step 6: Drop the old column
            migrationBuilder.DropColumn(
                name: "issueref",
                table: "IssueNoteheader");

            // Step 7: Rename the new column to the original column name
            migrationBuilder.RenameColumn(
                name: "new_issueref",
                table: "IssueNoteheader",
                newName: "issueref");

            // Step 8: Ensure no duplicates in the issueref column before adding the primary key
            migrationBuilder.Sql(@"
        IF EXISTS (
            SELECT 1
            FROM [IssueNoteheader]
            GROUP BY issueref
            HAVING COUNT(*) > 1
        )
        BEGIN
            THROW 50000, 'Cannot add primary key: Duplicate values found in issueref.', 1;
        END
    ");

            // Step 9: Add the primary key constraint on issueref
            migrationBuilder.Sql(@"
        ALTER TABLE [IssueNoteheader]
        ADD CONSTRAINT PK_IssueNoteheader PRIMARY KEY (issueref);
    ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop the primary key constraint if it exists
            migrationBuilder.Sql(@"
        ALTER TABLE [IssueNoteheader]
        DROP CONSTRAINT PK_IssueNoteheader;
    ");

            // Step 2: Add the old column back with the IDENTITY property (if required)
            migrationBuilder.AddColumn<int>(
                name: "issueref",
                table: "IssueNoteheader",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            // Step 3: Copy data from the current column to the old column
            migrationBuilder.Sql("UPDATE IssueNoteheader SET issueref = new_issueref");

            // Step 4: Add the primary key constraint to the issueref column
            migrationBuilder.Sql(@"
        ALTER TABLE [IssueNoteheader]
        ADD CONSTRAINT PK_IssueNoteheader PRIMARY KEY (issueref);
    ");

            // Step 5: Drop the new column
            migrationBuilder.DropColumn(
                name: "new_issueref",
                table: "IssueNoteheader");
        }
    }
}