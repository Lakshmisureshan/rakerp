using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
          public partial class adddatas : Migration
        {
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.CreateTable(
                    name: "Issuenotedetails",
                    columns: table => new
                    {
                        issuedetailid = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        issuenoteref = table.Column<int>(type: "int", nullable: false),
                        itemid = table.Column<int>(type: "int", nullable: false),
                        issueqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Issuenotedetails", x => x.issuedetailid);
                        table.ForeignKey(
                            name: "FK_Issuenotedetails_IssueNoteheader_issueref",
                            column: x => x.issuenoteref,
                            principalTable: "IssueNoteheader",
                            principalColumn: "issueref");
                        table.ForeignKey(
                            name: "FK_Issuenotedetails_Product_itemcode",
                            column: x => x.itemid,
                            principalTable: "Product",
                            principalColumn: "itemid");
                    });

            migrationBuilder.UpdateData(
           table: "AspNetUsers",
           keyColumn: "Id",
           keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
           columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
           values: new object[] { "3241079f-2051-4d9b-ae54-63708802b864", "AQAAAAEAACcQAAAAEJznPvHhUXaBKw5JE+DKUsTewEU5KkL2ZXRgmkCF7lhmEdVboVs4uakz7xLtT+ofrA==", "3e711b0d-ee69-4b07-8c37-1253db70291a" });

            migrationBuilder.CreateIndex(
                    name: "IX_Issuenotedetails_issuenoteref",
                    table: "Issuenotedetails",
                    column: "issuenoteref");

                migrationBuilder.CreateIndex(
                    name: "IX_Issuenotedetails_itemid",
                    table: "Issuenotedetails",
                    column: "itemid");
            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropTable(
                    name: "Issuenotedetails");


            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42527613-f2c8-44df-915c-b29dee36d94f", "AQAAAAEAACcQAAAAEJ8OgM1EIVbv6NCz3m/r9FG2x7hqGtGSE+pOjbEf/A9CcnxW1I/H5Nh8VRlJerP8tQ==", "aac81e22-833e-46fb-94a4-04046057244a" });
        }
        }
   



















}
