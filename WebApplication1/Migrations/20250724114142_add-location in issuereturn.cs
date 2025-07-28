using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addlocationinissuereturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "POissuereturndetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec7bb1f2-8659-4399-a07f-24b9f91d9ad9", "AQAAAAEAACcQAAAAEMPiIpIhyZT8iCXFt0ZDSc/PQ2AxD6ikI3VnsKrFngXLAzr6ouwpjmbHjRj6fXarhw==", "621df45b-e928-48e4-b85e-dd7446336719" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location",
                table: "POissuereturndetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fd11f6b-2a84-4fb1-a284-6bf519dbef67", "AQAAAAEAACcQAAAAECuBAv2HGvwq4L3JnWv+8NC2eF4iNTaBQvxa1OL/4MfLRl8B1r/WPZ9kT3Gm3SEWPg==", "e26250b7-8279-4f20-bce0-44e977f2e215" });
        }
    }
}
