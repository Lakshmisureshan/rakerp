using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pocurrencyid",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "poexchangerate",
                table: "PO",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e671339-903f-4659-91da-ec39e97852dd", "AQAAAAEAACcQAAAAEFxx52tFQvdvqTt/0iBFX4qF7GBclEb+4Z1YSOw7NaFhB6P23H9nlvBwwC0s59aTFg==", "a7f48bad-d410-44e2-ad8d-c3cd5abd9170" });

            migrationBuilder.CreateIndex(
                name: "IX_PO_pocurrencyid",
                table: "PO",
                column: "pocurrencyid");

            migrationBuilder.AddForeignKey(
                name: "FK_PO_Currency_pocurrencyid",
                table: "PO",
                column: "pocurrencyid",
                principalTable: "Currency",
                principalColumn: "currencyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PO_Currency_pocurrencyid",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_PO_pocurrencyid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "pocurrencyid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "poexchangerate",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26b963ce-9bc6-4716-8bec-9a06b6b7f5d2", "AQAAAAEAACcQAAAAEFaLQ9LQRAr9TiSMlWHdjwx4+nto68jTxQKTgxkxIdyfI+t6qhqfETm1nlRMQJ6G4Q==", "b89b0135-9499-4cde-9382-aa085e0a0f1c" });
        }
    }
}
