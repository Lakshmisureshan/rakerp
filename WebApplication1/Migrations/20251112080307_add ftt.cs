using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addftt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enquirydetails",
                columns: table => new
                {
                    enqtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enquiryref = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entrydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    entryuserid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquirydetails", x => x.enqtblid);
                    table.ForeignKey(
                        name: "FK_Enquirydetails_AspNetUsers_entryuserid",
                        column: x => x.entryuserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enquirydetails_Enquiry_Enquiryref",
                        column: x => x.Enquiryref,
                        principalTable: "Enquiry",
                        principalColumn: "Enquiryref");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "082935d8-470a-4657-bc2a-f910c91e7ba0", "AQAAAAEAACcQAAAAEE5P5CzboWpGdX4hqoefIP8rit5eh+9KV5KS6g+E6VzaMKhATnALwytbN7XrINxt/A==", "b5735ea0-539a-47b1-82ff-bafb22571df3" });

            migrationBuilder.CreateIndex(
                name: "IX_Enquirydetails_Enquiryref",
                table: "Enquirydetails",
                column: "Enquiryref");

            migrationBuilder.CreateIndex(
                name: "IX_Enquirydetails_entryuserid",
                table: "Enquirydetails",
                column: "entryuserid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enquirydetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3103763-f81c-44fd-8032-999377257717", "AQAAAAEAACcQAAAAELANZgCkA7OlGHnr3E6xebotolt03nsPH8R8oKVGby8rQMj97mCa+wmR/gpcFx40dQ==", "738aaeb7-b07c-4129-9426-d9c4e13729a4" });
        }
    }
}
