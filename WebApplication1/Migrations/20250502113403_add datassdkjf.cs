using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatassdkjf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "PO",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6059ce82-f658-4522-9094-c4a624a21948", "AQAAAAEAACcQAAAAEJerSI5/nchcn9mpSsLO+wRuHu8z/44IhWqU13HHfJ6XKbP7eVzD12NYZI6wzy+W+Q==", "77cc293e-8647-4085-a13c-276998bb2e13" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remarks",
                table: "PO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae5bcc96-af5f-4d55-bca5-e6c692936a9c", "AQAAAAEAACcQAAAAEFWjZ7skdGZTkx2IC9zHoOzDpjOVOwuOJJca7ZPxDjtdEKZ342ouU6QjjBBrfLHcmQ==", "84c9a459-0cb3-41dc-ae3c-2771e7422761" });
        }
    }
}
