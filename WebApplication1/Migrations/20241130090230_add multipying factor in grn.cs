using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addmultipyingfactoringrn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "multiplyingfactor",
                table: "GRNDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8b0ab62-0b9b-420b-a5d3-1d3bffc42f0a", "AQAAAAEAACcQAAAAEGs/G60ebLGMeMZiJakssiFh4aL0RucG6/hDRhtWmIXdXxZwMxxrGVIHRhBpa5o/4w==", "3307503b-f72b-4309-a2db-211ee1bc32b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "multiplyingfactor",
                table: "GRNDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d81dc79-d63f-49cc-8aca-1af71046f4f2", "AQAAAAEAACcQAAAAEKiNapVruSPvlNn8W222QenlkP+0T1MfTwSoZWSsjr/uCuEDvXgBQVlL1WRmeewMZg==", "e29552d6-a465-49cd-9320-273b11b81ff2" });
        }
    }
}
