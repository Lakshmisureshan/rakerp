using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class bg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the FK if it exists
            migrationBuilder.Sql(@"
                IF EXISTS (
                    SELECT 1 FROM sys.foreign_keys 
                    WHERE name = 'FK_Invoicedetails_Invoice_invoiceno2'
                )
                ALTER TABLE [Invoicedetails] DROP CONSTRAINT [FK_Invoicedetails_Invoice_invoiceno2];
            ");

            // Drop the index if it exists
            migrationBuilder.Sql(@"
                IF EXISTS (
                    SELECT 1 FROM sys.indexes 
                    WHERE name = 'IX_Invoicedetails_invoiceno2'
                )
                DROP INDEX [IX_Invoicedetails_invoiceno2] ON [Invoicedetails];
            ");

            // Drop the column if it exists
            migrationBuilder.Sql(@"
                IF EXISTS (
                    SELECT 1 FROM sys.columns 
                    WHERE Name = N'invoiceno2' AND Object_ID = Object_ID(N'Invoicedetails')
                )
                ALTER TABLE [Invoicedetails] DROP COLUMN [invoiceno2];
            ");

            // Add FK only if it does not already exist
            migrationBuilder.Sql(@"
                IF NOT EXISTS (
                    SELECT 1 FROM sys.foreign_keys 
                    WHERE name = 'FK_Invoicedetails_Invoice_invoiceno'
                )
                ALTER TABLE [Invoicedetails] ADD CONSTRAINT [FK_Invoicedetails_Invoice_invoiceno]
                FOREIGN KEY ([invoiceno]) REFERENCES [Invoice] ([invoiceno]) ON DELETE CASCADE;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Restore the column
            migrationBuilder.AddColumn<int>(
                name: "invoiceno2",
                table: "Invoicedetails",
                type: "int",
                nullable: true);

            // Restore index
            migrationBuilder.CreateIndex(
                name: "IX_Invoicedetails_invoiceno2",
                table: "Invoicedetails",
                column: "invoiceno2");

            // Restore foreign key
            migrationBuilder.AddForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno2",
                table: "Invoicedetails",
                column: "invoiceno2",
                principalTable: "Invoice",
                principalColumn: "invoiceno");

            // Also restore original FK (only if it was added above in `Up()`)
            migrationBuilder.AddForeignKey(
                name: "FK_Invoicedetails_Invoice_invoiceno",
                table: "Invoicedetails",
                column: "invoiceno",
                principalTable: "Invoice",
                principalColumn: "invoiceno");
        }
    }
}
