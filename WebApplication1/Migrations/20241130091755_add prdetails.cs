﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addprdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the pruomid column
            migrationBuilder.AddColumn<int>(
                name: "pruomid",
                table: "PRDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Handle conflicting records
            migrationBuilder.Sql(@"
                UPDATE PRDetails
                SET pruomid = (SELECT TOP 1 uomid FROM UOM)
                WHERE pruomid IS NOT NULL
                AND pruomid NOT IN (SELECT uomid FROM UOM);
            ");

            // Alternatively, if you want to delete conflicting records:
            // migrationBuilder.Sql(@"
            //     DELETE FROM PRDetails
            //     WHERE pruomid IS NOT NULL
            //     AND pruomid NOT IN (SELECT uomid FROM UOM);
            // ");

            // Update AspNetUsers table (optional, generated by EF Core)
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7968b595-7140-426e-ab8a-cc44d8a0de18", "AQAAAAEAACcQAAAAEBnoZx0+5Z6hCH+ZKa00xDMFPYG0xJVuvovtULjUYE6DvEAVahHz0HGKE6Cm2zsN7A==", "0bbf8b3e-37c4-465d-8552-279f1a44b699" });

            // Create the index for the foreign key
            migrationBuilder.CreateIndex(
                name: "IX_PRDetails_pruomid",
                table: "PRDetails",
                column: "pruomid");

            // Add the foreign key constraint
            migrationBuilder.AddForeignKey(
                name: "FK_PRDetails_UOM_pruomid",
                table: "PRDetails",
                column: "pruomid",
                principalTable: "UOM",
                principalColumn: "uomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the foreign key constraint
            migrationBuilder.DropForeignKey(
                name: "FK_PRDetails_UOM_pruomid",
                table: "PRDetails");

            // Remove the index
            migrationBuilder.DropIndex(
                name: "IX_PRDetails_pruomid",
                table: "PRDetails");

            // Drop the pruomid column
            migrationBuilder.DropColumn(
                name: "pruomid",
                table: "PRDetails");

            // Revert updates to AspNetUsers table (optional, generated by EF Core)
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8b0ab62-0b9b-420b-a5d3-1d3bffc42f0a", "AQAAAAEAACcQAAAAEGs/G60ebLGMeMZiJakssiFh4aL0RucG6/hDRhtWmIXdXxZwMxxrGVIHRhBpa5o/4w==", "3307503b-f72b-4309-a2db-211ee1bc32b9" });
        }
    }
}