using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addamountininvoicedetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                table: "Invoicedetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8fbd345d-5176-43eb-a8da-b6db38979f0f", "AQAAAAEAACcQAAAAENSgDovYhYmtMD+bX0BCyM+PV94k54lBlPutu6A2fJ60zPPka8YEWgM71h3RU3UWAA==", "87bb2613-91d0-4301-8e16-426c1ba77537" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "Invoicedetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0aaa0a8-f154-48a9-b06b-2974b20b3fee", "AQAAAAEAACcQAAAAEJvFnKt6hz9v2Gwfc8BrUCDxowlDHJ8qq8SAqRTvtlQ18mFNgLzj8SdohTrbl8azRQ==", "906b5352-48b7-4b7f-abed-08f6cf127d1f" });
        }
    }
}
