using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addjobnullfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "376fdee2-96e6-4e24-849b-e7a9df6b5ad1", "AQAAAAEAACcQAAAAEI3i1kmF1CUlOepPZCaH1lr2GI0mUkZmVlpghzwAyICrEN/aRf3o5F2Dkpkti4NCWw==", "fff2d68c-8e6e-4433-8a95-0403bc9c8499" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3458dee5-470a-4eab-b567-fa6646ebc9f6", "AQAAAAEAACcQAAAAEHUJrJ3hl7ANEpTbawgRRswuAo6UTIgztbj8p5tUZn0sDmvKR/CyNpNxaffUFz8YZA==", "c9e37102-3d7c-4734-acc9-18093991ce92" });
        }
    }
}
