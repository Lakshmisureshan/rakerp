using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatasfff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "POIssueReturnDetailIssueTracking",
                columns: table => new
                {
                    POIssueReturnDetailIssueTrackingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issuereturndetailid = table.Column<int>(type: "int", nullable: false),
                    issuetrackid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POIssueReturnDetailIssueTracking", x => x.POIssueReturnDetailIssueTrackingID);
                    table.ForeignKey(
                        name: "FK_POIssueReturnDetailIssueTracking_Issuetracking_issuetrackid",
                        column: x => x.issuetrackid,
                        principalTable: "Issuetracking",
                        principalColumn: "issuetrackid");
                    table.ForeignKey(
                        name: "FK_POIssueReturnDetailIssueTracking_POissuereturndetails_issuereturndetailid",
                        column: x => x.issuereturndetailid,
                        principalTable: "POissuereturndetails",
                        principalColumn: "issuereturndetailid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fd11f6b-2a84-4fb1-a284-6bf519dbef67", "AQAAAAEAACcQAAAAECuBAv2HGvwq4L3JnWv+8NC2eF4iNTaBQvxa1OL/4MfLRl8B1r/WPZ9kT3Gm3SEWPg==", "e26250b7-8279-4f20-bce0-44e977f2e215" });

            migrationBuilder.CreateIndex(
                name: "IX_POIssueReturnDetailIssueTracking_issuereturndetailid",
                table: "POIssueReturnDetailIssueTracking",
                column: "issuereturndetailid");

            migrationBuilder.CreateIndex(
                name: "IX_POIssueReturnDetailIssueTracking_issuetrackid",
                table: "POIssueReturnDetailIssueTracking",
                column: "issuetrackid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "POIssueReturnDetailIssueTracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9828ce7b-34da-4689-a2c7-b5d9d2522156", "AQAAAAEAACcQAAAAEDfIUXapXG2i0yh5UuKcyjtxVo6ul0znQwIZg6rDr7S9vBAkxj6L3oYJ31yyPv+Rwg==", "893839d2-f7e9-47e5-afaa-02939bae7a41" });
        }
    }
}
