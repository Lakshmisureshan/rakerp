using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class addcompanyidinemomaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_designation",
                table: "designation");

            migrationBuilder.RenameTable(
                name: "designation",
                newName: "Designation");

            // Add companyid with default value 1
            migrationBuilder.AddColumn<int>(
                name: "companyid",
                table: "Employeemaster",
                type: "int",
                nullable: false,
                defaultValue: 1);

            // Add designationid with default value 1
            migrationBuilder.AddColumn<int>(
                name: "designationid",
                table: "Employeemaster",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Designation",
                table: "Designation",
                column: "designationid");

            // Optional: Insert default company and designation if not already in database
            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM Company WHERE companyid = 1) INSERT INTO Company (companyid, companyname) VALUES (1, 'Default Company');");
            migrationBuilder.Sql("IF NOT EXISTS (SELECT 1 FROM Designation WHERE designationid = 1) INSERT INTO Designation (designationid, designationname) VALUES (1, 'Default Designation');");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57a036b3-93e5-46b1-9966-5b24bcb094e3", "AQAAAAEAACcQAAAAEPw+82UEjfGeMIlzEihis48sCtrKKM0IW+BSzSlO8kQUmwycQraWCSp2/8/kpsbQ0g==", "a17912d5-faef-4704-9b89-43333dceb3c2" });

            migrationBuilder.CreateIndex(
                name: "IX_Employeemaster_companyid",
                table: "Employeemaster",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "IX_Employeemaster_designationid",
                table: "Employeemaster",
                column: "designationid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeemaster_Company_companyid",
                table: "Employeemaster",
                column: "companyid",
                principalTable: "Company",
                principalColumn: "companyid");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeemaster_Designation_designationid",
                table: "Employeemaster",
                column: "designationid",
                principalTable: "Designation",
                principalColumn: "designationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeemaster_Company_companyid",
                table: "Employeemaster");

            migrationBuilder.DropForeignKey(
                name: "FK_Employeemaster_Designation_designationid",
                table: "Employeemaster");

            migrationBuilder.DropIndex(
                name: "IX_Employeemaster_companyid",
                table: "Employeemaster");

            migrationBuilder.DropIndex(
                name: "IX_Employeemaster_designationid",
                table: "Employeemaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Designation",
                table: "Designation");

            migrationBuilder.DropColumn(
                name: "companyid",
                table: "Employeemaster");

            migrationBuilder.DropColumn(
                name: "designationid",
                table: "Employeemaster");

            migrationBuilder.RenameTable(
                name: "Designation",
                newName: "designation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_designation",
                table: "designation",
                column: "designationid");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "356ff228-0e5f-436a-9ac5-2d760b997dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb809327-7fb5-4fdc-af49-7ead3fbca96a", "AQAAAAEAACcQAAAAEMMWjQJ3iGVSPcTTMq5t34HxcpjP01cl/NASfb8SLU+tpJOppPjnrM87hwuNnql/zg==", "1009c0e5-c15f-4108-894e-46e4c9c4f992" });
        }
    }
}