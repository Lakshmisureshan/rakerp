using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addquality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f45bfda4-6fae-451f-9456-a6e10823dbaa", "AQAAAAEAACcQAAAAEDznFt4Q03wHeqOf6BPaSRubV1UlCeojavMNgqctei8ZqrPrvcrzbKFHyC+Su/JjvQ==", "6f44a38c-ba6e-4be4-b7fb-9c87581dd6aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7080d66b-f0b6-46cc-ac71-8037b81a2679", "AQAAAAEAACcQAAAAEGiF60VeFZyJIZLJ1Unak0r3nDgkcYOgu/19RLniNc1w9fy4RWnyS/K3EFUU/nK4mQ==", "40c97337-36e8-49a3-a712-7b12708a1f0c" });
        }
    }
}
