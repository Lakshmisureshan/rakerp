using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addprstockqtyinprdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "prstockqty",
                table: "PRDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a2d135f4-2527-44ac-80d6-d18571beeb09", "AQAAAAEAACcQAAAAEGq9ZfXDLZvn0mZQtWceqNYzbp1TU5CpRnFQrBZMIsxzL9TESIXy/YmzflferSC0LA==", "5e898580-1769-472d-8d05-59e3a1de77b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prstockqty",
                table: "PRDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4e13cbf-2788-4a87-a35b-513d709f91fd", "AQAAAAEAACcQAAAAEGUTDKFOJIr0/L0s+YjIkpHeBd9E9twhl7psiNYVEoix5nG2zoweUSJrqxwyBnPlqA==", "8e620a10-4b1f-46ba-bc5b-93e3d81c2227" });
        }
    }
}
