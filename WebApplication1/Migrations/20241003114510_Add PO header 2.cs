using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class AddPOheader2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Mtcrequired",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Others",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "POPaymentterms2id",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymenttermsDaysid",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Qtndate",
                table: "PO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "approveddrawings",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "chineseorgin",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "coorequired",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "deliverydate",
                table: "PO",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "extendedwarraty3years",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "mtcpriortodispatch",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "podeliverytermsid",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "popaymenttermsid",
                table: "PO",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "predispatchinspection",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "qtnattached",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "qtnshippingdocs",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "suppliertrnno",
                table: "PO",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "warranty",
                table: "PO",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PaymenttermsDays",
                columns: table => new
                {
                    paydaysid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paydaynames = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymenttermsDays", x => x.paydaysid);
                });

            migrationBuilder.CreateTable(
                name: "PODeliveryTerms",
                columns: table => new
                {
                    deliveryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryterms = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PODeliveryTerms", x => x.deliveryid);
                });

            migrationBuilder.CreateTable(
                name: "POPaymentterms",
                columns: table => new
                {
                    paytermsid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymenttermsname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_POPaymentterms", x => x.paytermsid);
                });

            migrationBuilder.CreateTable(
                name: "Popaymentterms2",
                columns: table => new
                {
                    paytermsid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paymenttermsname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Popaymentterms2", x => x.paytermsid);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26b963ce-9bc6-4716-8bec-9a06b6b7f5d2", "AQAAAAEAACcQAAAAEFaLQ9LQRAr9TiSMlWHdjwx4+nto68jTxQKTgxkxIdyfI+t6qhqfETm1nlRMQJ6G4Q==", "b89b0135-9499-4cde-9382-aa085e0a0f1c" });

            migrationBuilder.CreateIndex(
                name: "IX_PO_PaymenttermsDaysid",
                table: "PO",
                column: "PaymenttermsDaysid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_podeliverytermsid",
                table: "PO",
                column: "podeliverytermsid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_POPaymentterms2id",
                table: "PO",
                column: "POPaymentterms2id");

            migrationBuilder.CreateIndex(
                name: "IX_PO_popaymenttermsid",
                table: "PO",
                column: "popaymenttermsid");

            migrationBuilder.AddForeignKey(
                name: "FK_PO_PaymenttermsDays_PaymenttermsDaysid",
                table: "PO",
                column: "PaymenttermsDaysid",
                principalTable: "PaymenttermsDays",
                principalColumn: "paydaysid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PO_PODeliveryTerms_podeliverytermsid",
                table: "PO",
                column: "podeliverytermsid",
                principalTable: "PODeliveryTerms",
                principalColumn: "deliveryid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PO_POPaymentterms_popaymenttermsid",
                table: "PO",
                column: "popaymenttermsid",
                principalTable: "POPaymentterms",
                principalColumn: "paytermsid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PO_Popaymentterms2_POPaymentterms2id",
                table: "PO",
                column: "POPaymentterms2id",
                principalTable: "Popaymentterms2",
                principalColumn: "paytermsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PO_PaymenttermsDays_PaymenttermsDaysid",
                table: "PO");

            migrationBuilder.DropForeignKey(
                name: "FK_PO_PODeliveryTerms_podeliverytermsid",
                table: "PO");

            migrationBuilder.DropForeignKey(
                name: "FK_PO_POPaymentterms_popaymenttermsid",
                table: "PO");

            migrationBuilder.DropForeignKey(
                name: "FK_PO_Popaymentterms2_POPaymentterms2id",
                table: "PO");

            migrationBuilder.DropTable(
                name: "PaymenttermsDays");

            migrationBuilder.DropTable(
                name: "PODeliveryTerms");

            migrationBuilder.DropTable(
                name: "POPaymentterms");

            migrationBuilder.DropTable(
                name: "Popaymentterms2");

            migrationBuilder.DropIndex(
                name: "IX_PO_PaymenttermsDaysid",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_PO_podeliverytermsid",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_PO_POPaymentterms2id",
                table: "PO");

            migrationBuilder.DropIndex(
                name: "IX_PO_popaymenttermsid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "Mtcrequired",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "Others",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "POPaymentterms2id",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "PaymenttermsDaysid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "Qtndate",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "approveddrawings",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "chineseorgin",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "coorequired",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "deliverydate",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "extendedwarraty3years",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "mtcpriortodispatch",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "podeliverytermsid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "popaymenttermsid",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "predispatchinspection",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "qtnattached",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "qtnshippingdocs",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "suppliertrnno",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "warranty",
                table: "PO");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71ff2a34-26f7-4593-9483-6f7787138fd2", "AQAAAAEAACcQAAAAEJ3PQCpEPFwP52tq0X68QbdufJb9iRIOtH2+9G8UTOllFcF9QslkjPdC4DjDOMYzHQ==", "64cba825-8291-4898-b679-1d996ec3ccc4" });
        }
    }
}
