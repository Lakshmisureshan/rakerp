using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addsuppliercontract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "supplierid",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "suppliercontactid",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a30d8a1a-9387-4b1b-a2ab-a5de081830cf", "AQAAAAEAACcQAAAAENbxX4k/b27cjI1ii6yvBNkwi3J4+XPjUHgCkv/zdHwQcv09paY4aZmW5k3tYkiuEg==", "6b0f5530-2f68-477c-b94d-8b43eb31d68e" });

            migrationBuilder.CreateIndex(
                name: "IX_PO_suppliercontactid",
                table: "PO",
                column: "suppliercontactid");

            migrationBuilder.AddForeignKey(
                name: "FK_PO_SupplierContact_suppliercontactid",
                table: "PO",
                column: "suppliercontactid",
                principalTable: "SupplierContact",
                principalColumn: "suppliercontectid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PO_SupplierContact_suppliercontactid",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_PO_suppliercontactid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "suppliercontactid",
                table: "PO");

            migrationBuilder.AlterColumn<int>(
                name: "supplierid",
                table: "PO",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f994404c-3601-43ff-9cec-1822e895d9bb", "AQAAAAEAACcQAAAAENQz0CWvQUlDdI+E80/k2c6cGHKMWn+8CcsJDdv4DVffmlHgWehQDgTjhB/vhkuASg==", "f6beba44-5f37-4546-9950-34294aeb8674" });
        }
    }
}
