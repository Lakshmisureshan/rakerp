using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Addsuppliercontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierContact",
                columns: table => new
                {
                    suppliercontectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierid = table.Column<int>(type: "int", nullable: false),
                    suppliercontactname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierContact", x => x.suppliercontectid);
                    table.ForeignKey(
                        name: "FK_SupplierContact_Supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "Supplier",
                        principalColumn: "supplierid");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18fbe9fb-b6d3-44bb-973e-5028c9aa2009", "AQAAAAEAACcQAAAAECJyGFT79OuSKQfNCcYgP4Xv738RSVHp0YG3v+v3VLUzpu1RKX1HKcGmvGkFMlbzLQ==", "94ff041e-6774-42dc-961c-3cd14c058ae8" });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContact_supplierid",
                table: "SupplierContact",
                column: "supplierid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierContact");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b8aefa7-6a49-4812-92ff-bbcd834b480d", "AQAAAAEAACcQAAAAEIX3KzER3CMpxwoUDyDCG2mlUOUmxtyRVegphtM9gRK+bfcVUeNZxDJ1DIQMXLe+Yg==", "d262265e-5155-4b47-984d-40d0987c6d6e" });
        }
    }
}
