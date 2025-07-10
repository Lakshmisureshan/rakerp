using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class fhgbj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b0641d5-76b6-4d59-b94c-72b77cd03e3a", "AQAAAAEAACcQAAAAEKwYvwr05y/r7mcb6lhJSVa07gjj9TfF6qam2v110HVO2NcJrQZfoY/Wt+r2PsT22g==", "1473e99e-63b3-43b9-a8d7-69ca63342846" });

            migrationBuilder.InsertData(
                table: "CompanyInfo",
                columns: new[] { "Id", "Bank1AEDAccount", "Bank1Branch", "Bank1Name", "Bank1SWIFT", "Bank1USDAccount", "Bank2AEDAccount", "Bank2Branch", "Bank2Name", "Bank2SWIFT", "Bank2USDAccount", "ClarificationContact", "ClarificationDays", "CompanyAddressLine1", "CompanyAddressLine2", "CompanyEmail", "CompanyFax", "CompanyName", "CompanyPhone", "CompanyTRN", "CompanyWebsite", "InvoiceFormatNo" },
                values: new object[] { 1, "AE 41 0330 0000 1900 0028 744", "Branch 12, King Abdul Aziz Branch Sharjah, UAE", "Mashreq Bank Psc", "BOMLAEAD", "AE 29 0330 0000 1900 0036 332", "AE 89 0350 0000 0620 6483 580", "Ras Al Riffa Branch, Ras Al Khaimah, UAE", "NBAD", "NBADAEAARAK", "AE 50 0350 0000 0620 6483 603", "00971 56 610 3421", 7, "P.O Box 85652, RAK-UAE", "Dengg.FZ-LLC", "info@ace-me.com", "+971 6 5269062", "Ace Cranes & Engineering FZ-LLC", "+971 7 2445002", "100296598400003", "www.ace-me.com", "ACE-ACC-F-03, REV.00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CompanyInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb8d7e28-8c18-4ccd-bfb2-2707bcd83416", "AQAAAAEAACcQAAAAEEeBfoKGWT1djfEkdwlS7Gjb6oFL6smgMCHCRixQGIH9Uf9ScMsLe0r+OkiQZEqjYA==", "3154a116-cfa1-40ac-a3da-e73e03b4c61a" });
        }
    }
}
