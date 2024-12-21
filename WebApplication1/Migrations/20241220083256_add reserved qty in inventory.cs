using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addreservedqtyininventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "reservedqty",
                table: "Inventory",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4e13cbf-2788-4a87-a35b-513d709f91fd", "AQAAAAEAACcQAAAAEGUTDKFOJIr0/L0s+YjIkpHeBd9E9twhl7psiNYVEoix5nG2zoweUSJrqxwyBnPlqA==", "8e620a10-4b1f-46ba-bc5b-93e3d81c2227" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservedqty",
                table: "Inventory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaa0b984-8730-4472-b934-6cdb3b962d12", "AQAAAAEAACcQAAAAEADVItah5rOsJ/UP9iyoxbrFAbvoquYay9iwoZdOUSGLeWXgSBprMbw+5gDGSWd2mg==", "0079eda2-1ab9-47a8-86b7-b33b6047b181" });
        }
    }
}
