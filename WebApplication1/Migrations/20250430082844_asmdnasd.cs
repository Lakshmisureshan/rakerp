using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class asmdnasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "extension",
                table: "customercontact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43be0d6e-abc1-42e7-ac59-a2a45fef6965", "AQAAAAEAACcQAAAAEN7dceJvT5mEWpFSRPf9y2izS3RjiQlUjms9zTMiPwGvjRlOdoBIVRn6cCHVF9pijA==", "35102598-6827-4924-9b53-9e5ba097b9d0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "extension",
                table: "customercontact");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e4c77e1-fb36-49b7-ab99-2919ae5cbd65", "AQAAAAEAACcQAAAAEJaQ5sJBXRIGSghpdpCv/RgOxmC27/bWvON28Xz2t2NAP8GuPP6ZWLl2ghUhad6law==", "4620f270-85b9-4ef7-918e-80f9887c67de" });
        }
    }
}
