using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatas2356623 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enquirydetails_Enquiry_Enquiryref",
                table: "Enquirydetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Enquirydetails_Enquiry_Enquiryref2",
                table: "Enquirydetails");

            migrationBuilder.DropIndex(
                name: "IX_Enquirydetails_Enquiryref2",
                table: "Enquirydetails");

            migrationBuilder.DropColumn(
                name: "Enquiryref2",
                table: "Enquirydetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fc0ea5c-c982-454d-888f-46ff92a4a00d", "AQAAAAEAACcQAAAAEM41bNN1vyBHHl6OTKwEdCUHquDH6OMUIxP8qG9Y/HVAO0n+61rJ3DkOiIuai7ZBxg==", "73e7dc82-ecd5-4116-80a3-e58a1864ce37" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enquirydetails_Enquiry_Enquiryref",
                table: "Enquirydetails",
                column: "Enquiryref",
                principalTable: "Enquiry",
                principalColumn: "Enquiryref",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enquirydetails_Enquiry_Enquiryref",
                table: "Enquirydetails");

            migrationBuilder.AddColumn<int>(
                name: "Enquiryref2",
                table: "Enquirydetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d037021-0525-41a6-97cb-3b4f74caac51", "AQAAAAEAACcQAAAAEFdyOiUKjtqGugJCc1aDSwUi8NNICGSQrbeVwHEdRtI1Bnct0BlLPeWnl0o/jxrwgA==", "62953761-80e9-42b1-8260-ce16cf76b17a" });

            migrationBuilder.CreateIndex(
                name: "IX_Enquirydetails_Enquiryref2",
                table: "Enquirydetails",
                column: "Enquiryref2");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquirydetails_Enquiry_Enquiryref",
                table: "Enquirydetails",
                column: "Enquiryref",
                principalTable: "Enquiry",
                principalColumn: "Enquiryref");

            migrationBuilder.AddForeignKey(
                name: "FK_Enquirydetails_Enquiry_Enquiryref2",
                table: "Enquirydetails",
                column: "Enquiryref2",
                principalTable: "Enquiry",
                principalColumn: "Enquiryref");
        }
    }
}
