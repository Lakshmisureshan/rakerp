using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class Adduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    passcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BudgettHeader",
                columns: table => new
                {
                    budgetheaderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    budgetheadername = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgettHeader", x => x.budgetheaderid);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    countryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countryname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.countryid);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    currencyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currencyname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exchangerate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.currencyid);
                });

            migrationBuilder.CreateTable(
                name: "IsLDApplicable",
                columns: table => new
                {
                    ldid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLDApplicableName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsLDApplicable", x => x.ldid);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    jobtypeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobtypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.jobtypeid);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingBay",
                columns: table => new
                {
                    BayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingBay", x => x.BayId);
                });

            migrationBuilder.CreateTable(
                name: "ProductionStages",
                columns: table => new
                {
                    prostageid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productionstagename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionStages", x => x.prostageid);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCategory",
                columns: table => new
                {
                    projectcategoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectcategoryname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCategory", x => x.projectcategoryid);
                });

            migrationBuilder.CreateTable(
                name: "PRstatus",
                columns: table => new
                {
                    prstatusid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prstatusname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRstatus", x => x.prstatusid);
                });

            migrationBuilder.CreateTable(
                name: "QualityLevel",
                columns: table => new
                {
                    qualitylevelid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qualitylevelname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityLevel", x => x.qualitylevelid);
                });

            migrationBuilder.CreateTable(
                name: "UOM",
                columns: table => new
                {
                    uomid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uomname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOM", x => x.uomid);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    wId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warehousename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.wId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ccode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shortname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trnno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IEC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pobox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    web = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryid = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerid);
                    table.ForeignKey(
                        name: "FK_Customer_Country_countryid",
                        column: x => x.countryid,
                        principalTable: "Country",
                        principalColumn: "countryid");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    itemid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemdescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    standarduomid = table.Column<int>(type: "int", nullable: false),
                    itembudgetheaderid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.itemid);
                    table.ForeignKey(
                        name: "FK_Product_BudgettHeader_itembudgetheaderid",
                        column: x => x.itembudgetheaderid,
                        principalTable: "BudgettHeader",
                        principalColumn: "budgetheaderid");
                    table.ForeignKey(
                        name: "FK_Product_UOM_standarduomid",
                        column: x => x.standarduomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Jobid = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    jobtypeid = table.Column<int>(type: "int", nullable: false),
                    jobdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lpodate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lpono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectmanagerid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    projectengineerid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    totalnumber = table.Column<int>(type: "int", nullable: false),
                    manufacturingbayid = table.Column<int>(type: "int", nullable: false),
                    qualitylevelid = table.Column<int>(type: "int", nullable: false),
                    podeliverydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectcategoryid = table.Column<int>(type: "int", nullable: false),
                    isldapplicable = table.Column<int>(type: "int", nullable: false),
                    ldpercent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currencyid = table.Column<int>(type: "int", nullable: false),
                    exchangerate = table.Column<double>(type: "float", nullable: false),
                    ordervalue = table.Column<double>(type: "float", nullable: false),
                    ordervaluebasecurrency = table.Column<double>(type: "float", nullable: false),
                    projectname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentterms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    warrantyterms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deliveryterms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bomjobrevno = table.Column<int>(type: "int", nullable: false),
                    bomjobstatusid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Jobid);
                    table.ForeignKey(
                        name: "FK_Job_AspNetUsers_projectengineerid",
                        column: x => x.projectengineerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Job_AspNetUsers_projectmanagerid",
                        column: x => x.projectmanagerid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Job_Currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Job_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_IsLDApplicable_isldapplicable",
                        column: x => x.isldapplicable,
                        principalTable: "IsLDApplicable",
                        principalColumn: "ldid");
                    table.ForeignKey(
                        name: "FK_Job_JobType_jobtypeid",
                        column: x => x.jobtypeid,
                        principalTable: "JobType",
                        principalColumn: "jobtypeid");
                    table.ForeignKey(
                        name: "FK_Job_ManufacturingBay_manufacturingbayid",
                        column: x => x.manufacturingbayid,
                        principalTable: "ManufacturingBay",
                        principalColumn: "BayId");
                    table.ForeignKey(
                        name: "FK_Job_ProjectCategory_projectcategoryid",
                        column: x => x.projectcategoryid,
                        principalTable: "ProjectCategory",
                        principalColumn: "projectcategoryid");
                    table.ForeignKey(
                        name: "FK_Job_QualityLevel_qualitylevelid",
                        column: x => x.qualitylevelid,
                        principalTable: "QualityLevel",
                        principalColumn: "qualitylevelid");
                });

            migrationBuilder.CreateTable(
                name: "UomMultiplyingFactor",
                columns: table => new
                {
                    muid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    fromuomid = table.Column<int>(type: "int", nullable: false),
                    touomid = table.Column<int>(type: "int", nullable: false),
                    conversionfactor = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UomMultiplyingFactor", x => x.muid);
                    table.ForeignKey(
                        name: "FK_UomMultiplyingFactor_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_UomMultiplyingFactor_UOM_fromuomid",
                        column: x => x.fromuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                    table.ForeignKey(
                        name: "FK_UomMultiplyingFactor_UOM_touomid",
                        column: x => x.touomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "Bom",
                columns: table => new
                {
                    bomid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    bomqty = table.Column<double>(type: "float", nullable: false),
                    bomuomid = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    prodstageid = table.Column<int>(type: "int", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    currencyid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    bomrevno = table.Column<int>(type: "int", nullable: false),
                    bomstatus = table.Column<int>(type: "int", nullable: false),
                    prcreatedqty = table.Column<double>(type: "float", nullable: false),
                    bomcreatedbyid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BomcreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bom", x => x.bomid);
                    table.ForeignKey(
                        name: "FK_Bom_AspNetUsers_bomcreatedbyid",
                        column: x => x.bomcreatedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bom_Currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Bom_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Bom_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Bom_ProductionStages_prodstageid",
                        column: x => x.prodstageid,
                        principalTable: "ProductionStages",
                        principalColumn: "prostageid");
                    table.ForeignKey(
                        name: "FK_Bom_UOM_bomuomid",
                        column: x => x.bomuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "PR",
                columns: table => new
                {
                    PRID = table.Column<int>(type: "int", nullable: false),
                    Prdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    verifiedbyid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    prstatusid = table.Column<int>(type: "int", nullable: false),
                    prverificationdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PR", x => x.PRID);
                    table.ForeignKey(
                        name: "FK_PR_AspNetUsers_verifiedbyid",
                        column: x => x.verifiedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PR_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_PR_PRstatus_prstatusid",
                        column: x => x.prstatusid,
                        principalTable: "PRstatus",
                        principalColumn: "prstatusid");
                });

            migrationBuilder.CreateTable(
                name: "PRDetails",
                columns: table => new
                {
                    prtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prid = table.Column<int>(type: "int", nullable: false),
                    pritemid = table.Column<int>(type: "int", nullable: false),
                    bomid = table.Column<int>(type: "int", nullable: false),
                    prqty = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRDetails", x => x.prtblid);
                    table.ForeignKey(
                        name: "FK_PRDetails_Bom_bomid",
                        column: x => x.bomid,
                        principalTable: "Bom",
                        principalColumn: "bomid");
                    table.ForeignKey(
                        name: "FK_PRDetails_PR_prid",
                        column: x => x.prid,
                        principalTable: "PR",
                        principalColumn: "PRID");
                    table.ForeignKey(
                        name: "FK_PRDetails_Product_pritemid",
                        column: x => x.pritemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c8cdf22-752c-446a-bb42-9bea05872bd5", "3c8cdf22-752c-446a-bb42-9bea05872bd5", "TradeManager", "TRADEMANAGER" },
                    { "72c35b91-4022-4c2b-adc3-1ec004c08a21", "72c35b91-4022-4c2b-adc3-1ec004c08a21", "FinanceManager", "FINANCEMANAGER" },
                    { "9ab357a2-67a2-4be8-82fd-12339553dd8b", "9ab357a2-67a2-4be8-82fd-12339553dd8b", "Writer", "WRITER" },
                    { "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "TradeUser", "TRADEUSER" },
                    { "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "passcode" },
                values: new object[] { "356ff228-0e5f-436a-9ac5-2d760b997dd5", 0, "aa0626f3-2b21-4aaa-b40e-9797b90eaf8d", "admin@trading.com", false, false, null, "ADMIN@TRADING.COM", "ADMIN@TRADING.COM", "AQAAAAEAACcQAAAAEGu/oxIhZUP5rknAZRU83Pc2wMxKS2kGcoSszTQoFKdoDQ2UjnoLP38cYKcKB8tG0Q==", null, false, "07332b60-5be5-4758-a5fc-bf91b4efc3d1", false, "admin@trading.com", "123456" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3c8cdf22-752c-446a-bb42-9bea05872bd5", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "72c35b91-4022-4c2b-adc3-1ec004c08a21", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "9ab357a2-67a2-4be8-82fd-12339553dd8b", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "356ff228-0e5f-436a-9ac5-2d760b997dd5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bom_bomcreatedbyid",
                table: "Bom",
                column: "bomcreatedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_Bom_bomuomid",
                table: "Bom",
                column: "bomuomid");

            migrationBuilder.CreateIndex(
                name: "IX_Bom_currencyid",
                table: "Bom",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Bom_itemid",
                table: "Bom",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_Bom_jobid",
                table: "Bom",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Bom_prodstageid",
                table: "Bom",
                column: "prodstageid");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_countryid",
                table: "Customer",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_currencyid",
                table: "Job",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_customerid",
                table: "Job",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_isldapplicable",
                table: "Job",
                column: "isldapplicable");

            migrationBuilder.CreateIndex(
                name: "IX_Job_jobtypeid",
                table: "Job",
                column: "jobtypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_manufacturingbayid",
                table: "Job",
                column: "manufacturingbayid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_projectcategoryid",
                table: "Job",
                column: "projectcategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_projectengineerid",
                table: "Job",
                column: "projectengineerid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_projectmanagerid",
                table: "Job",
                column: "projectmanagerid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_qualitylevelid",
                table: "Job",
                column: "qualitylevelid");

            migrationBuilder.CreateIndex(
                name: "IX_PR_jobid",
                table: "PR",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_PR_prstatusid",
                table: "PR",
                column: "prstatusid");

            migrationBuilder.CreateIndex(
                name: "IX_PR_verifiedbyid",
                table: "PR",
                column: "verifiedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_PRDetails_bomid",
                table: "PRDetails",
                column: "bomid");

            migrationBuilder.CreateIndex(
                name: "IX_PRDetails_prid",
                table: "PRDetails",
                column: "prid");

            migrationBuilder.CreateIndex(
                name: "IX_PRDetails_pritemid",
                table: "PRDetails",
                column: "pritemid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_itembudgetheaderid",
                table: "Product",
                column: "itembudgetheaderid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_standarduomid",
                table: "Product",
                column: "standarduomid");

            migrationBuilder.CreateIndex(
                name: "IX_UomMultiplyingFactor_fromuomid",
                table: "UomMultiplyingFactor",
                column: "fromuomid");

            migrationBuilder.CreateIndex(
                name: "IX_UomMultiplyingFactor_itemid",
                table: "UomMultiplyingFactor",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_UomMultiplyingFactor_touomid",
                table: "UomMultiplyingFactor",
                column: "touomid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PRDetails");

            migrationBuilder.DropTable(
                name: "UomMultiplyingFactor");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bom");

            migrationBuilder.DropTable(
                name: "PR");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductionStages");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "PRstatus");

            migrationBuilder.DropTable(
                name: "BudgettHeader");

            migrationBuilder.DropTable(
                name: "UOM");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "IsLDApplicable");

            migrationBuilder.DropTable(
                name: "JobType");

            migrationBuilder.DropTable(
                name: "ManufacturingBay");

            migrationBuilder.DropTable(
                name: "ProjectCategory");

            migrationBuilder.DropTable(
                name: "QualityLevel");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
