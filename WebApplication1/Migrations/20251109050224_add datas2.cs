using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatas2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.AddColumn<int>(
                           name: "isverified",
                           table: "Enquiry",
                           type: "int",
                           nullable: false,
                           defaultValue: 0);



            migrationBuilder.AddColumn<string>(
                name: "completedbybyuserid",
                table: "Enquiry",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "completiondate",
                table: "Enquiry",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "iscompleted",
                table: "Enquiry",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "verifiedbydate",
                table: "Enquiry",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "verifiedbyuserid",
                table: "Enquiry",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5de5a5d6-efd1-46f0-a69a-9a559cde4e82", "AQAAAAEAACcQAAAAELlC02Cp3WeyCsC3oUWIVaNMEwqOcJe3G9ZmVDGPZeT+HrpoPHFFC59TmVi7pY6Iug==", "4ac54746-540c-480d-a7ab-5bcd8aa80a57" });

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_completedbybyuserid",
                table: "Enquiry",
                column: "completedbybyuserid");

          

            migrationBuilder.CreateIndex(
                name: "IX_Enquiry_verifiedbyuserid",
                table: "Enquiry",
                column: "verifiedbyuserid");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquiry_AspNetUsers_completedbybyuserid",
                table: "Enquiry",
                column: "completedbybyuserid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquiry_AspNetUsers_verifiedbyuserid",
                table: "Enquiry",
                column: "verifiedbyuserid",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enquiry_AspNetUsers_completedbybyuserid",
                table: "Enquiry");

            migrationBuilder.DropForeignKey(
                name: "FK_Enquiry_AspNetUsers_verifiedbyuserid",
                table: "Enquiry");

     

            migrationBuilder.DropIndex(
                name: "IX_Enquiry_completedbybyuserid",
                table: "Enquiry");

           

            migrationBuilder.DropIndex(
                name: "IX_Enquiry_verifiedbyuserid",
                table: "Enquiry");

         

            migrationBuilder.DropColumn(
                name: "completedbybyuserid",
                table: "Enquiry");

            migrationBuilder.DropColumn(
                name: "completiondate",
                table: "Enquiry");

            migrationBuilder.DropColumn(
                name: "iscompleted",
                table: "Enquiry");

            migrationBuilder.DropColumn(
              name: "isverified",
              table: "Enquiry");



            migrationBuilder.DropColumn(
                name: "verifiedbydate",
                table: "Enquiry");

            migrationBuilder.DropColumn(
                name: "verifiedbyuserid",
                table: "Enquiry");

      

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b214768-d75b-413b-833b-6515af628cbd", "AQAAAAEAACcQAAAAELke7w3slGwX7AmdHxsCZMOQnWhA8CNTqLzeHN2cFlVrtMw8459DcEw+lkOV5fLFpw==", "3a2a41c2-2d1d-48bc-9802-21515623a8b5" });

        
        }
    }
}
