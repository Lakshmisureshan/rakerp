using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addshdfbs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "totalreturnedqty",
                table: "Issuetracking",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ed2b6fc-5494-452b-8947-310775658962", "AQAAAAEAACcQAAAAEBH6XuHNkt/COE/z2kqxmRHN1MoaSWtbvs52omsEkrxtMDqk6qn20rL+uRWUw1c/Tg==", "ae7131b2-7855-4fa6-98c2-3b297a27c08c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "totalreturnedqty",
                table: "Issuetracking");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09840ff2-ce05-42c1-bd1a-f1e43ce183b4", "AQAAAAEAACcQAAAAEOzs1t/i1PXzKL/MFiFZ2vhq5Qp1NCdwBVTz/wjTGt1y41hFbpDinVCVBR5rgnszrg==", "416b3df3-569e-4179-8797-ad1edbc172e4" });
        }
    }
}
