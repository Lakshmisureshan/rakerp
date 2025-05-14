using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addlocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "location",
                table: "GRNDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8e3f613-8138-4cd9-9f33-6fcc8a137273", "AQAAAAEAACcQAAAAEMCp5QNdfc6Mz3dyWz7AfCiM61WmCcYnSIxvmiTeFn5F2uEkPAEz5aoVfkL0LiJjLg==", "637b1133-c950-46f5-8169-9422cb4d4e04" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location",
                table: "GRNDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "394de643-26d3-4b30-b4b4-422fe22ed87d", "AQAAAAEAACcQAAAAEBXSFhCqKcmFUHz3gBDp892et+4bObXuq6hhyt8fgcAINleaJA3Jvg/jEUDegl255Q==", "e5b81ac4-6050-4a07-8363-1d9db4f28293" });
        }
    }
}
