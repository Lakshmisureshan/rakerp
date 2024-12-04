using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsupplieraddress1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "supplieraddress",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6571ef91-4f86-43f1-8fad-f4fdbc798bd2", "AQAAAAEAACcQAAAAEJln2Q8U8BUqY8IVzDMQI4wZVdjfjtGseYUHTCZhIKgNAxJu12o4WjwoFB1zM1F7/w==", "ab10deef-d00e-4e84-81e9-536ec5ff1fe0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "supplieraddress",
                table: "Supplier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18fbe9fb-b6d3-44bb-973e-5028c9aa2009", "AQAAAAEAACcQAAAAECJyGFT79OuSKQfNCcYgP4Xv738RSVHp0YG3v+v3VLUzpu1RKX1HKcGmvGkFMlbzLQ==", "94ff041e-6774-42dc-961c-3cd14c058ae8" });
        }
    }
}
