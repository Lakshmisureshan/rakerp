using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class adddatassdhfds : Migration
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
                name: "BaseCurrency",
                columns: table => new
                {
                    basecurrencyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    basecurrency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseCurrency", x => x.basecurrencyid);
                });

            migrationBuilder.CreateTable(
                name: "BudgettHeader",
                columns: table => new
                {
                    budgetheaderid = table.Column<int>(type: "int", nullable: false),
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
                    currencyid = table.Column<int>(type: "int", nullable: false),
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
                name: "JobStage",
                columns: table => new
                {
                    jobstageid = table.Column<int>(type: "int", nullable: false),
                    jobstagename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStage", x => x.jobstageid);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    jobtypeid = table.Column<int>(type: "int", nullable: false),
                    JobtypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startingseries = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "postatus",
                columns: table => new
                {
                    postatusid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    postatusname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postatus", x => x.postatusid);
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
                name: "Supplier",
                columns: table => new
                {
                    supplierid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    suppliername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplieraddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    suppliertrnno = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.supplierid);
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
                name: "Category",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    categoryname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    budgetheaderid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryid);
                    table.ForeignKey(
                        name: "FK_Category_BudgettHeader_budgetheaderid",
                        column: x => x.budgetheaderid,
                        principalTable: "BudgettHeader",
                        principalColumn: "budgetheaderid");
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
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    subcategoryid = table.Column<int>(type: "int", nullable: false),
                    subcategoryname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.subcategoryid);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "categoryid");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Jobid = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    jobtypeid = table.Column<int>(type: "int", nullable: false),
                    jobdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lpodate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lpono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectmanagerid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    projectengineerid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    totalnumber = table.Column<int>(type: "int", nullable: false),
                    manufacturingbayid = table.Column<int>(type: "int", nullable: false),
                    qualitylevelid = table.Column<int>(type: "int", nullable: true),
                    podeliverydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    projectcategoryid = table.Column<int>(type: "int", nullable: true),
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
                    bomjobstatusid = table.Column<int>(type: "int", nullable: false),
                    enduserid = table.Column<int>(type: "int", nullable: false),
                    mainjobid = table.Column<int>(type: "int", nullable: true),
                    expecteddeliverydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobdescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bomjobrevno2 = table.Column<int>(type: "int", nullable: false),
                    bomjobstatusid2 = table.Column<int>(type: "int", nullable: false),
                    totalinvoiceinbasecurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    jobstageid = table.Column<int>(type: "int", nullable: false),
                    pruexpense1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pruexpense2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    totalreceivedinbasecurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                        name: "FK_Job_Customer_enduserid",
                        column: x => x.enduserid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_Job_IsLDApplicable_isldapplicable",
                        column: x => x.isldapplicable,
                        principalTable: "IsLDApplicable",
                        principalColumn: "ldid");
                    table.ForeignKey(
                        name: "FK_Job_JobStage_jobstageid",
                        column: x => x.jobstageid,
                        principalTable: "JobStage",
                        principalColumn: "jobstageid");
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
                name: "ReceiptVoucher",
                columns: table => new
                {
                    receiptid = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    rvcurrencyid = table.Column<int>(type: "int", nullable: false),
                    rvexchangerate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rvamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rvamountaed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rvamountwords = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cheque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    chequedate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    bankname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receiptdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    rvreamrks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isregistered = table.Column<int>(type: "int", nullable: false),
                    createdbyid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptVoucher", x => x.receiptid);
                    table.ForeignKey(
                        name: "FK_ReceiptVoucher_AspNetUsers_createdbyid",
                        column: x => x.createdbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReceiptVoucher_Currency_rvcurrencyid",
                        column: x => x.rvcurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_ReceiptVoucher_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    itemid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productcode = table.Column<int>(type: "int", nullable: false),
                    itemcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itembname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    itemdescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    standarduomid = table.Column<int>(type: "int", nullable: false),
                    itembudgetheaderid = table.Column<int>(type: "int", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false),
                    subcategoryid = table.Column<int>(type: "int", nullable: false),
                    reorderqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    reorderlevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                        name: "FK_Product_Category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "categoryid");
                    table.ForeignKey(
                        name: "FK_Product_SubCategory_subcategoryid",
                        column: x => x.subcategoryid,
                        principalTable: "SubCategory",
                        principalColumn: "subcategoryid");
                    table.ForeignKey(
                        name: "FK_Product_UOM_standarduomid",
                        column: x => x.standarduomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "FixedBudget",
                columns: table => new
                {
                    fixedbudgetid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    budgetId = table.Column<int>(type: "int", nullable: false),
                    fixedamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    revision = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedBudget", x => x.fixedbudgetid);
                    table.ForeignKey(
                        name: "FK_FixedBudget_BudgettHeader_budgetId",
                        column: x => x.budgetId,
                        principalTable: "BudgettHeader",
                        principalColumn: "budgetheaderid");
                    table.ForeignKey(
                        name: "FK_FixedBudget_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    invoiceno = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LPOno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LPODate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    invcurrencyid = table.Column<int>(type: "int", nullable: false),
                    isregistered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.invoiceno);
                    table.ForeignKey(
                        name: "FK_Invoice_Currency_invcurrencyid",
                        column: x => x.invcurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_Invoice_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.CreateTable(
                name: "IssueNoteheader",
                columns: table => new
                {
                    issueref = table.Column<int>(type: "int", nullable: false),
                    issuedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    issuedto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isregistered = table.Column<int>(type: "int", nullable: false),
                    issuetype = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueNoteheader", x => x.issueref);
                    table.ForeignKey(
                        name: "FK_IssueNoteheader_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.CreateTable(
                name: "Issuereturn",
                columns: table => new
                {
                    issuereturnref = table.Column<int>(type: "int", nullable: false),
                    returndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isregistered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuereturn", x => x.issuereturnref);
                    table.ForeignKey(
                        name: "FK_Issuereturn_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.CreateTable(
                name: "Miscost",
                columns: table => new
                {
                    misid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    misamount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscost", x => x.misid);
                    table.ForeignKey(
                        name: "FK_Miscost_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.CreateTable(
                name: "PO",
                columns: table => new
                {
                    Orderid = table.Column<int>(type: "int", nullable: false),
                    Podate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    createddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    pocurrencyid = table.Column<int>(type: "int", nullable: false),
                    poexchangerate = table.Column<double>(type: "float", nullable: false),
                    createdbyid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    modifiedbyid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    poverifiedbyid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PoAuthorizedbyid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    poauthorizedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    poverifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    supplierid = table.Column<int>(type: "int", nullable: false),
                    supplieraddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    suppliercontactid = table.Column<int>(type: "int", nullable: false),
                    Qtnref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qtndate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    suppliertrnno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    podeliverytermsid = table.Column<int>(type: "int", nullable: false),
                    deliverydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    popaymenttermsid = table.Column<int>(type: "int", nullable: false),
                    PaymenttermsDaysid = table.Column<int>(type: "int", nullable: false),
                    POPaymentterms2id = table.Column<int>(type: "int", nullable: false),
                    Mtcrequired = table.Column<bool>(type: "bit", nullable: false),
                    coorequired = table.Column<bool>(type: "bit", nullable: false),
                    predispatchinspection = table.Column<bool>(type: "bit", nullable: false),
                    warranty = table.Column<bool>(type: "bit", nullable: false),
                    chineseorgin = table.Column<bool>(type: "bit", nullable: false),
                    mtcpriortodispatch = table.Column<bool>(type: "bit", nullable: false),
                    extendedwarraty3years = table.Column<bool>(type: "bit", nullable: false),
                    qtnattached = table.Column<bool>(type: "bit", nullable: false),
                    qtnshippingdocs = table.Column<bool>(type: "bit", nullable: false),
                    approveddrawings = table.Column<bool>(type: "bit", nullable: false),
                    Others = table.Column<bool>(type: "bit", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postatusid = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PO", x => x.Orderid);
                    table.ForeignKey(
                        name: "FK_PO_AspNetUsers_createdbyid",
                        column: x => x.createdbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PO_AspNetUsers_modifiedbyid",
                        column: x => x.modifiedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PO_AspNetUsers_PoAuthorizedbyid",
                        column: x => x.PoAuthorizedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PO_AspNetUsers_poverifiedbyid",
                        column: x => x.poverifiedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PO_Currency_pocurrencyid",
                        column: x => x.pocurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_PO_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_PO_PaymenttermsDays_PaymenttermsDaysid",
                        column: x => x.PaymenttermsDaysid,
                        principalTable: "PaymenttermsDays",
                        principalColumn: "paydaysid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PO_PODeliveryTerms_podeliverytermsid",
                        column: x => x.podeliverytermsid,
                        principalTable: "PODeliveryTerms",
                        principalColumn: "deliveryid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PO_POPaymentterms_popaymenttermsid",
                        column: x => x.popaymenttermsid,
                        principalTable: "POPaymentterms",
                        principalColumn: "paytermsid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PO_Popaymentterms2_POPaymentterms2id",
                        column: x => x.POPaymentterms2id,
                        principalTable: "Popaymentterms2",
                        principalColumn: "paytermsid");
                    table.ForeignKey(
                        name: "FK_PO_postatus_postatusid",
                        column: x => x.postatusid,
                        principalTable: "postatus",
                        principalColumn: "postatusid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PO_Supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "Supplier",
                        principalColumn: "supplierid");
                    table.ForeignKey(
                        name: "FK_PO_SupplierContact_suppliercontactid",
                        column: x => x.suppliercontactid,
                        principalTable: "SupplierContact",
                        principalColumn: "suppliercontectid");
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
                    prverificationdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    prcreatedbyid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PR", x => x.PRID);
                    table.ForeignKey(
                        name: "FK_PR_AspNetUsers_prcreatedbyid",
                        column: x => x.prcreatedbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    BomcreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    bomnumber = table.Column<int>(type: "int", nullable: false)
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
                name: "estimation",
                columns: table => new
                {
                    estimationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    applicationid = table.Column<int>(type: "int", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false),
                    currencyid = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    isconvertedtobom = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estimation", x => x.estimationid);
                    table.ForeignKey(
                        name: "FK_estimation_Currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_estimation_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_estimation_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_estimation_ProductionStages_applicationid",
                        column: x => x.applicationid,
                        principalTable: "ProductionStages",
                        principalColumn: "prostageid");
                    table.ForeignKey(
                        name: "FK_estimation_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
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
                name: "Invoicedetails",
                columns: table => new
                {
                    invidno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceno = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitprice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    qty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    counter = table.Column<int>(type: "int", nullable: false),
                    vatpercent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    taxamount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoicedetails", x => x.invidno);
                    table.ForeignKey(
                        name: "FK_Invoicedetails_Invoice_invoiceno",
                        column: x => x.invoiceno,
                        principalTable: "Invoice",
                        principalColumn: "invoiceno");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceReg",
                columns: table => new
                {
                    invoiceregid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invoiceno = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    currencyid = table.Column<int>(type: "int", nullable: false),
                    Invoicevalue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Invoicevalueinbasecurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Invoicereceipts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Invoiceregisteredby = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceReg", x => x.invoiceregid);
                    table.ForeignKey(
                        name: "FK_InvoiceReg_AspNetUsers_Invoiceregisteredby",
                        column: x => x.Invoiceregisteredby,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceReg_Currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_InvoiceReg_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_InvoiceReg_Invoice_invoiceno",
                        column: x => x.invoiceno,
                        principalTable: "Invoice",
                        principalColumn: "invoiceno");
                    table.ForeignKey(
                        name: "FK_InvoiceReg_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                });

            migrationBuilder.CreateTable(
                name: "receipt",
                columns: table => new
                {
                    rtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receiptid = table.Column<int>(type: "int", nullable: false),
                    invoiceid = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false),
                    amountinbasecurrency = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Createdbyid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createdbydate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receipt", x => x.rtblid);
                    table.ForeignKey(
                        name: "FK_receipt_AspNetUsers_Createdbyid",
                        column: x => x.Createdbyid,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_receipt_Customer_customerid",
                        column: x => x.customerid,
                        principalTable: "Customer",
                        principalColumn: "customerid");
                    table.ForeignKey(
                        name: "FK_receipt_Invoice_invoiceid",
                        column: x => x.invoiceid,
                        principalTable: "Invoice",
                        principalColumn: "invoiceno");
                    table.ForeignKey(
                        name: "FK_receipt_ReceiptVoucher_receiptid",
                        column: x => x.receiptid,
                        principalTable: "ReceiptVoucher",
                        principalColumn: "receiptid");
                });

            migrationBuilder.CreateTable(
                name: "Issuenotedetails",
                columns: table => new
                {
                    issuedetailid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issuenoteref = table.Column<int>(type: "int", nullable: false),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    issueqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuenotedetails", x => x.issuedetailid);
                    table.ForeignKey(
                        name: "FK_Issuenotedetails_IssueNoteheader_issuenoteref",
                        column: x => x.issuenoteref,
                        principalTable: "IssueNoteheader",
                        principalColumn: "issueref");
                    table.ForeignKey(
                        name: "FK_Issuenotedetails_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.CreateTable(
                name: "Issuetracking",
                columns: table => new
                {
                    issuetrackid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invid = table.Column<int>(type: "int", nullable: true),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    issuenoteno = table.Column<int>(type: "int", nullable: false),
                    issuedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    issueqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    issueunitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    issuecurrencyid = table.Column<int>(type: "int", nullable: false),
                    issueuomid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuetracking", x => x.issuetrackid);
                    table.ForeignKey(
                        name: "FK_Issuetracking_Currency_issuecurrencyid",
                        column: x => x.issuecurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Issuetracking_IssueNoteheader_issuenoteno",
                        column: x => x.issuenoteno,
                        principalTable: "IssueNoteheader",
                        principalColumn: "issueref");
                    table.ForeignKey(
                        name: "FK_Issuetracking_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Issuetracking_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Issuetracking_UOM_issueuomid",
                        column: x => x.issueuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "issuereturntracking",
                columns: table => new
                {
                    issuereturntrackid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    issuereturnno = table.Column<int>(type: "int", nullable: false),
                    issuereturndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    issuereturnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    issuereturnunitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    issuecurrencyid = table.Column<int>(type: "int", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issuereturntracking", x => x.issuereturntrackid);
                    table.ForeignKey(
                        name: "FK_issuereturntracking_Currency_issuecurrencyid",
                        column: x => x.issuecurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_issuereturntracking_Issuereturn_issuereturnno",
                        column: x => x.issuereturnno,
                        principalTable: "Issuereturn",
                        principalColumn: "issuereturnref");
                    table.ForeignKey(
                        name: "FK_issuereturntracking_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_issuereturntracking_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_issuereturntracking_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "GRNHeader",
                columns: table => new
                {
                    grnno = table.Column<int>(type: "int", nullable: false),
                    grndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false),
                    isregistered = table.Column<int>(type: "int", nullable: false),
                    currencyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNHeader", x => x.grnno);
                    table.ForeignKey(
                        name: "FK_GRNHeader_Currency_currencyid",
                        column: x => x.currencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GRNHeader_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    invid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    batchid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Entrydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false),
                    invcurrencyid = table.Column<int>(type: "int", nullable: false),
                    invprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    reservedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.invid);
                    table.ForeignKey(
                        name: "FK_Inventory_Currency_invcurrencyid",
                        column: x => x.invcurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Inventory_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Inventory_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                    table.ForeignKey(
                        name: "FK_Inventory_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Inventory_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "Purchasedetails",
                columns: table => new
                {
                    potblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderid = table.Column<int>(type: "int", nullable: false),
                    poitemid = table.Column<int>(type: "int", nullable: false),
                    poquantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pounitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    receivedentryqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    inspacceptedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    grncreatedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pouomid = table.Column<int>(type: "int", nullable: false),
                    inspholdqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    insprejectedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchasedetails", x => x.potblid);
                    table.ForeignKey(
                        name: "FK_Purchasedetails_PO_orderid",
                        column: x => x.orderid,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                    table.ForeignKey(
                        name: "FK_Purchasedetails_Product_poitemid",
                        column: x => x.poitemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Purchasedetails_UOM_pouomid",
                        column: x => x.pouomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "ReceivedEntry",
                columns: table => new
                {
                    REID = table.Column<int>(type: "int", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isregistered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedEntry", x => x.REID);
                    table.ForeignKey(
                        name: "FK_ReceivedEntry_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
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
                    pocreatedqty = table.Column<float>(type: "real", nullable: false),
                    prqty = table.Column<float>(type: "real", nullable: false),
                    pruomid = table.Column<int>(type: "int", nullable: false),
                    prstockqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_PRDetails_UOM_pruomid",
                        column: x => x.pruomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "GRNDetails",
                columns: table => new
                {
                    grntblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    grnno = table.Column<int>(type: "int", nullable: false),
                    itemcode = table.Column<int>(type: "int", nullable: false),
                    grnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    pouomid = table.Column<int>(type: "int", nullable: false),
                    inventoryuomid = table.Column<int>(type: "int", nullable: false),
                    multiplyingfactor = table.Column<double>(type: "float", nullable: false),
                    pounitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRNDetails", x => x.grntblid);
                    table.ForeignKey(
                        name: "FK_GRNDetails_GRNHeader_grnno",
                        column: x => x.grnno,
                        principalTable: "GRNHeader",
                        principalColumn: "grnno");
                    table.ForeignKey(
                        name: "FK_GRNDetails_Product_itemcode",
                        column: x => x.itemcode,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_GRNDetails_UOM_inventoryuomid",
                        column: x => x.inventoryuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                    table.ForeignKey(
                        name: "FK_GRNDetails_UOM_pouomid",
                        column: x => x.pouomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "grntracking",
                columns: table => new
                {
                    grntrackid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    invid = table.Column<int>(type: "int", nullable: false),
                    jobid = table.Column<int>(type: "int", nullable: false),
                    grnno = table.Column<int>(type: "int", nullable: false),
                    grndate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    grnqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    grnunitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    grncurrencyid = table.Column<int>(type: "int", nullable: false),
                    grnuomid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grntracking", x => x.grntrackid);
                    table.ForeignKey(
                        name: "FK_grntracking_Currency_grncurrencyid",
                        column: x => x.grncurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_grntracking_GRNHeader_grnno",
                        column: x => x.grnno,
                        principalTable: "GRNHeader",
                        principalColumn: "grnno");
                    table.ForeignKey(
                        name: "FK_grntracking_Job_jobid",
                        column: x => x.jobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_grntracking_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_grntracking_UOM_grnuomid",
                        column: x => x.grnuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "Materialinspection",
                columns: table => new
                {
                    mid = table.Column<int>(type: "int", nullable: false),
                    midate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    pono = table.Column<int>(type: "int", nullable: false),
                    reid = table.Column<int>(type: "int", nullable: false),
                    isregistered = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qtyverified = table.Column<bool>(type: "bit", nullable: false),
                    phycondn = table.Column<bool>(type: "bit", nullable: false),
                    heattags = table.Column<bool>(type: "bit", nullable: false),
                    colorcoding = table.Column<bool>(type: "bit", nullable: false),
                    siteidentification = table.Column<bool>(type: "bit", nullable: false),
                    correlation = table.Column<bool>(type: "bit", nullable: false),
                    tcverify = table.Column<bool>(type: "bit", nullable: false),
                    materialsent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materialinspection", x => x.mid);
                    table.ForeignKey(
                        name: "FK_Materialinspection_PO_pono",
                        column: x => x.pono,
                        principalTable: "PO",
                        principalColumn: "Orderid");
                    table.ForeignKey(
                        name: "FK_Materialinspection_ReceivedEntry_reid",
                        column: x => x.reid,
                        principalTable: "ReceivedEntry",
                        principalColumn: "REID");
                });

            migrationBuilder.CreateTable(
                name: "ReceivedEntryDetails",
                columns: table => new
                {
                    rtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RENO = table.Column<int>(type: "int", nullable: false),
                    receivedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    potblid = table.Column<int>(type: "int", nullable: false),
                    acceptedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rejectedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    holdqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedEntryDetails", x => x.rtblid);
                    table.ForeignKey(
                        name: "FK_ReceivedEntryDetails_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_ReceivedEntryDetails_Purchasedetails_potblid",
                        column: x => x.potblid,
                        principalTable: "Purchasedetails",
                        principalColumn: "potblid");
                    table.ForeignKey(
                        name: "FK_ReceivedEntryDetails_ReceivedEntry_RENO",
                        column: x => x.RENO,
                        principalTable: "ReceivedEntry",
                        principalColumn: "REID");
                });

            migrationBuilder.CreateTable(
                name: "Inventoryreservation",
                columns: table => new
                {
                    RId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    inventoryid = table.Column<int>(type: "int", nullable: false),
                    fromjobid = table.Column<int>(type: "int", nullable: false),
                    tojobid = table.Column<int>(type: "int", nullable: false),
                    reservedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    productid = table.Column<int>(type: "int", nullable: false),
                    uomid = table.Column<int>(type: "int", nullable: false),
                    issuecreatedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    invunitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    reservationtime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    prtblid = table.Column<int>(type: "int", nullable: false),
                    invrcurrencyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventoryreservation", x => x.RId);
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Currency_invrcurrencyid",
                        column: x => x.invrcurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Inventory_inventoryid",
                        column: x => x.inventoryid,
                        principalTable: "Inventory",
                        principalColumn: "invid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Job_fromjobid",
                        column: x => x.fromjobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Job_tojobid",
                        column: x => x.tojobid,
                        principalTable: "Job",
                        principalColumn: "Jobid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_PRDetails_prtblid",
                        column: x => x.prtblid,
                        principalTable: "PRDetails",
                        principalColumn: "prtblid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Inventoryreservation_UOM_uomid",
                        column: x => x.uomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "PRPO",
                columns: table => new
                {
                    prpotblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prdetailsprtblid = table.Column<int>(type: "int", nullable: false),
                    Purchasedetailspotblid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRPO", x => x.prpotblid);
                    table.ForeignKey(
                        name: "FK_PRPO_PRDetails_prdetailsprtblid",
                        column: x => x.prdetailsprtblid,
                        principalTable: "PRDetails",
                        principalColumn: "prtblid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRPO_Purchasedetails_Purchasedetailspotblid",
                        column: x => x.Purchasedetailspotblid,
                        principalTable: "Purchasedetails",
                        principalColumn: "potblid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MIdetails",
                columns: table => new
                {
                    mitblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mid = table.Column<int>(type: "int", nullable: false),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    acceptedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rejectedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    holdqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MIdetails", x => x.mitblid);
                    table.ForeignKey(
                        name: "FK_MIdetails_Materialinspection_mid",
                        column: x => x.mid,
                        principalTable: "Materialinspection",
                        principalColumn: "mid");
                    table.ForeignKey(
                        name: "FK_MIdetails_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                });

            migrationBuilder.CreateTable(
                name: "IssuedetailsfromStock",
                columns: table => new
                {
                    issuedetailid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    issuenoteref = table.Column<int>(type: "int", nullable: false),
                    itemid = table.Column<int>(type: "int", nullable: false),
                    issueqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rid = table.Column<int>(type: "int", nullable: false),
                    issueprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    returnedqty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    issueuomid = table.Column<int>(type: "int", nullable: false),
                    issuecurrencyid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedetailsfromStock", x => x.issuedetailid);
                    table.ForeignKey(
                        name: "FK_IssuedetailsfromStock_Currency_issuecurrencyid",
                        column: x => x.issuecurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_IssuedetailsfromStock_Inventoryreservation_rid",
                        column: x => x.rid,
                        principalTable: "Inventoryreservation",
                        principalColumn: "RId");
                    table.ForeignKey(
                        name: "FK_IssuedetailsfromStock_IssueNoteheader_issuenoteref",
                        column: x => x.issuenoteref,
                        principalTable: "IssueNoteheader",
                        principalColumn: "issueref");
                    table.ForeignKey(
                        name: "FK_IssuedetailsfromStock_Product_itemid",
                        column: x => x.itemid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_IssuedetailsfromStock_UOM_issueuomid",
                        column: x => x.issueuomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.CreateTable(
                name: "Issuereturndetails",
                columns: table => new
                {
                    irtblid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productid = table.Column<int>(type: "int", nullable: false),
                    quantityreturned = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    issuereturnref = table.Column<int>(type: "int", nullable: false),
                    issuedetailtblid = table.Column<int>(type: "int", nullable: false),
                    irunitprice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ircurrencyid = table.Column<int>(type: "int", nullable: false),
                    iruomid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuereturndetails", x => x.irtblid);
                    table.ForeignKey(
                        name: "FK_Issuereturndetails_Currency_ircurrencyid",
                        column: x => x.ircurrencyid,
                        principalTable: "Currency",
                        principalColumn: "currencyid");
                    table.ForeignKey(
                        name: "FK_Issuereturndetails_IssuedetailsfromStock_issuedetailtblid",
                        column: x => x.issuedetailtblid,
                        principalTable: "IssuedetailsfromStock",
                        principalColumn: "issuedetailid");
                    table.ForeignKey(
                        name: "FK_Issuereturndetails_Issuereturn_issuereturnref",
                        column: x => x.issuereturnref,
                        principalTable: "Issuereturn",
                        principalColumn: "issuereturnref");
                    table.ForeignKey(
                        name: "FK_Issuereturndetails_Product_productid",
                        column: x => x.productid,
                        principalTable: "Product",
                        principalColumn: "itemid");
                    table.ForeignKey(
                        name: "FK_Issuereturndetails_UOM_iruomid",
                        column: x => x.iruomid,
                        principalTable: "UOM",
                        principalColumn: "uomid");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad", "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad", "PRVerification", "PRVERIFICATION" },
                    { "333559dc-c729-403c-a80e-77250b8a0592", "333559dc-c729-403c-a80e-77250b8a0592", "POAuthorization", "POAUTHORIZATION" },
                    { "3c8cdf22-752c-446a-bb42-9bea05872bd5", "3c8cdf22-752c-446a-bb42-9bea05872bd5", "TradeManager", "TRADEMANAGER" },
                    { "5e648847-b462-464d-8e1e-aa20a7947bef", "5e648847-b462-464d-8e1e-aa20a7947bef", "POVerification", "POVERIFICATION" },
                    { "72c35b91-4022-4c2b-adc3-1ec004c08a21", "72c35b91-4022-4c2b-adc3-1ec004c08a21", "FinanceManager", "FINANCEMANAGER" },
                    { "9ab357a2-67a2-4be8-82fd-12339553dd8b", "9ab357a2-67a2-4be8-82fd-12339553dd8b", "Writer", "WRITER" },
                    { "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "TradeUser", "TRADEUSER" },
                    { "e05d3da2-24c8-43fb-859f-cdbee6ac2a73", "e05d3da2-24c8-43fb-859f-cdbee6ac2a73", "GRNRegistration", "GRNREGISTRATION" },
                    { "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "e76b0657-67f3-4e84-9320-1ed68a80a8f5", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "passcode" },
                values: new object[] { "356ff228-0e5f-436a-9ac5-2d760b997dd5", 0, "2fd3518a-fd0d-4519-ac3a-435d7743804b", "admin@trading.com", false, false, null, "ADMIN@TRADING.COM", "ADMIN@TRADING.COM", "AQAAAAEAACcQAAAAENxK8qTllbwgzZvLCkYra8DrQ13iCMyr4ZuXytGciiFGI1g+NNgHozQq4mEo3DNafg==", null, false, "07d53beb-6c03-4af7-8480-9a766d29512d", false, "admin@trading.com", "123456" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "333559dc-c729-403c-a80e-77250b8a0592", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "3c8cdf22-752c-446a-bb42-9bea05872bd5", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "5e648847-b462-464d-8e1e-aa20a7947bef", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "72c35b91-4022-4c2b-adc3-1ec004c08a21", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "9ab357a2-67a2-4be8-82fd-12339553dd8b", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "b52de381-7ff6-4d7f-a385-51fa28f43aaa", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
                    { "e05d3da2-24c8-43fb-859f-cdbee6ac2a73", "356ff228-0e5f-436a-9ac5-2d760b997dd5" },
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
                name: "IX_Category_budgetheaderid",
                table: "Category",
                column: "budgetheaderid");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_countryid",
                table: "Customer",
                column: "countryid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_applicationid",
                table: "estimation",
                column: "applicationid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_currencyid",
                table: "estimation",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_itemid",
                table: "estimation",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_jobid",
                table: "estimation",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_estimation_uomid",
                table: "estimation",
                column: "uomid");

            migrationBuilder.CreateIndex(
                name: "IX_FixedBudget_budgetId",
                table: "FixedBudget",
                column: "budgetId");

            migrationBuilder.CreateIndex(
                name: "IX_FixedBudget_jobid",
                table: "FixedBudget",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_grnno",
                table: "GRNDetails",
                column: "grnno");

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_inventoryuomid",
                table: "GRNDetails",
                column: "inventoryuomid");

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_itemcode",
                table: "GRNDetails",
                column: "itemcode");

            migrationBuilder.CreateIndex(
                name: "IX_GRNDetails_pouomid",
                table: "GRNDetails",
                column: "pouomid");

            migrationBuilder.CreateIndex(
                name: "IX_GRNHeader_currencyid",
                table: "GRNHeader",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_GRNHeader_pono",
                table: "GRNHeader",
                column: "pono");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_grncurrencyid",
                table: "grntracking",
                column: "grncurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_grnno",
                table: "grntracking",
                column: "grnno");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_grnuomid",
                table: "grntracking",
                column: "grnuomid");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_jobid",
                table: "grntracking",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_grntracking_productid",
                table: "grntracking",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_invcurrencyid",
                table: "Inventory",
                column: "invcurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_jobid",
                table: "Inventory",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_pono",
                table: "Inventory",
                column: "pono");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_productid",
                table: "Inventory",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_uomid",
                table: "Inventory",
                column: "uomid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_fromjobid",
                table: "Inventoryreservation",
                column: "fromjobid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_inventoryid",
                table: "Inventoryreservation",
                column: "inventoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_invrcurrencyid",
                table: "Inventoryreservation",
                column: "invrcurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_productid",
                table: "Inventoryreservation",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_prtblid",
                table: "Inventoryreservation",
                column: "prtblid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_tojobid",
                table: "Inventoryreservation",
                column: "tojobid");

            migrationBuilder.CreateIndex(
                name: "IX_Inventoryreservation_uomid",
                table: "Inventoryreservation",
                column: "uomid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_customerid",
                table: "Invoice",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_invcurrencyid",
                table: "Invoice",
                column: "invcurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_jobid",
                table: "Invoice",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoicedetails_invoiceno",
                table: "Invoicedetails",
                column: "invoiceno");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReg_currencyid",
                table: "InvoiceReg",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReg_customerid",
                table: "InvoiceReg",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReg_invoiceno",
                table: "InvoiceReg",
                column: "invoiceno");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReg_Invoiceregisteredby",
                table: "InvoiceReg",
                column: "Invoiceregisteredby");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceReg_jobid",
                table: "InvoiceReg",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_issuecurrencyid",
                table: "IssuedetailsfromStock",
                column: "issuecurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_issuenoteref",
                table: "IssuedetailsfromStock",
                column: "issuenoteref");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_issueuomid",
                table: "IssuedetailsfromStock",
                column: "issueuomid");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_itemid",
                table: "IssuedetailsfromStock",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedetailsfromStock_rid",
                table: "IssuedetailsfromStock",
                column: "rid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuenotedetails_issuenoteref",
                table: "Issuenotedetails",
                column: "issuenoteref");

            migrationBuilder.CreateIndex(
                name: "IX_Issuenotedetails_itemid",
                table: "Issuenotedetails",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_IssueNoteheader_jobid",
                table: "IssueNoteheader",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturn_jobid",
                table: "Issuereturn",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_ircurrencyid",
                table: "Issuereturndetails",
                column: "ircurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_iruomid",
                table: "Issuereturndetails",
                column: "iruomid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_issuedetailtblid",
                table: "Issuereturndetails",
                column: "issuedetailtblid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_issuereturnref",
                table: "Issuereturndetails",
                column: "issuereturnref");

            migrationBuilder.CreateIndex(
                name: "IX_Issuereturndetails_productid",
                table: "Issuereturndetails",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_issuecurrencyid",
                table: "issuereturntracking",
                column: "issuecurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_issuereturnno",
                table: "issuereturntracking",
                column: "issuereturnno");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_jobid",
                table: "issuereturntracking",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_productid",
                table: "issuereturntracking",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_issuereturntracking_uomid",
                table: "issuereturntracking",
                column: "uomid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_issuecurrencyid",
                table: "Issuetracking",
                column: "issuecurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_issuenoteno",
                table: "Issuetracking",
                column: "issuenoteno");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_issueuomid",
                table: "Issuetracking",
                column: "issueuomid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_jobid",
                table: "Issuetracking",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_Issuetracking_productid",
                table: "Issuetracking",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_currencyid",
                table: "Job",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_customerid",
                table: "Job",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_enduserid",
                table: "Job",
                column: "enduserid");

            migrationBuilder.CreateIndex(
                name: "IX_Job_isldapplicable",
                table: "Job",
                column: "isldapplicable");

            migrationBuilder.CreateIndex(
                name: "IX_Job_jobstageid",
                table: "Job",
                column: "jobstageid");

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
                name: "IX_Materialinspection_pono",
                table: "Materialinspection",
                column: "pono");

            migrationBuilder.CreateIndex(
                name: "IX_Materialinspection_reid",
                table: "Materialinspection",
                column: "reid");

            migrationBuilder.CreateIndex(
                name: "IX_MIdetails_itemid",
                table: "MIdetails",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_MIdetails_mid",
                table: "MIdetails",
                column: "mid");

            migrationBuilder.CreateIndex(
                name: "IX_Miscost_jobid",
                table: "Miscost",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_createdbyid",
                table: "PO",
                column: "createdbyid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_jobid",
                table: "PO",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_modifiedbyid",
                table: "PO",
                column: "modifiedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_PaymenttermsDaysid",
                table: "PO",
                column: "PaymenttermsDaysid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_PoAuthorizedbyid",
                table: "PO",
                column: "PoAuthorizedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_pocurrencyid",
                table: "PO",
                column: "pocurrencyid");

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

            migrationBuilder.CreateIndex(
                name: "IX_PO_postatusid",
                table: "PO",
                column: "postatusid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_poverifiedbyid",
                table: "PO",
                column: "poverifiedbyid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_suppliercontactid",
                table: "PO",
                column: "suppliercontactid");

            migrationBuilder.CreateIndex(
                name: "IX_PO_supplierid",
                table: "PO",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_PR_jobid",
                table: "PR",
                column: "jobid");

            migrationBuilder.CreateIndex(
                name: "IX_PR_prcreatedbyid",
                table: "PR",
                column: "prcreatedbyid");

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
                name: "IX_PRDetails_pruomid",
                table: "PRDetails",
                column: "pruomid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_categoryid",
                table: "Product",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_itembudgetheaderid",
                table: "Product",
                column: "itembudgetheaderid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_standarduomid",
                table: "Product",
                column: "standarduomid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_subcategoryid",
                table: "Product",
                column: "subcategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_PRPO_prdetailsprtblid",
                table: "PRPO",
                column: "prdetailsprtblid");

            migrationBuilder.CreateIndex(
                name: "IX_PRPO_Purchasedetailspotblid",
                table: "PRPO",
                column: "Purchasedetailspotblid");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_orderid",
                table: "Purchasedetails",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_poitemid",
                table: "Purchasedetails",
                column: "poitemid");

            migrationBuilder.CreateIndex(
                name: "IX_Purchasedetails_pouomid",
                table: "Purchasedetails",
                column: "pouomid");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_Createdbyid",
                table: "receipt",
                column: "Createdbyid");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_customerid",
                table: "receipt",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_invoiceid",
                table: "receipt",
                column: "invoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_receipt_receiptid",
                table: "receipt",
                column: "receiptid");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVoucher_createdbyid",
                table: "ReceiptVoucher",
                column: "createdbyid");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVoucher_customerid",
                table: "ReceiptVoucher",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptVoucher_rvcurrencyid",
                table: "ReceiptVoucher",
                column: "rvcurrencyid");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntry_pono",
                table: "ReceivedEntry",
                column: "pono");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntryDetails_itemid",
                table: "ReceivedEntryDetails",
                column: "itemid");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntryDetails_potblid",
                table: "ReceivedEntryDetails",
                column: "potblid");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedEntryDetails_RENO",
                table: "ReceivedEntryDetails",
                column: "RENO");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_categoryid",
                table: "SubCategory",
                column: "categoryid");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierContact_supplierid",
                table: "SupplierContact",
                column: "supplierid");

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
                name: "BaseCurrency");

            migrationBuilder.DropTable(
                name: "estimation");

            migrationBuilder.DropTable(
                name: "FixedBudget");

            migrationBuilder.DropTable(
                name: "GRNDetails");

            migrationBuilder.DropTable(
                name: "grntracking");

            migrationBuilder.DropTable(
                name: "Invoicedetails");

            migrationBuilder.DropTable(
                name: "InvoiceReg");

            migrationBuilder.DropTable(
                name: "Issuenotedetails");

            migrationBuilder.DropTable(
                name: "Issuereturndetails");

            migrationBuilder.DropTable(
                name: "issuereturntracking");

            migrationBuilder.DropTable(
                name: "Issuetracking");

            migrationBuilder.DropTable(
                name: "MIdetails");

            migrationBuilder.DropTable(
                name: "Miscost");

            migrationBuilder.DropTable(
                name: "PRPO");

            migrationBuilder.DropTable(
                name: "receipt");

            migrationBuilder.DropTable(
                name: "ReceivedEntryDetails");

            migrationBuilder.DropTable(
                name: "UomMultiplyingFactor");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "GRNHeader");

            migrationBuilder.DropTable(
                name: "IssuedetailsfromStock");

            migrationBuilder.DropTable(
                name: "Issuereturn");

            migrationBuilder.DropTable(
                name: "Materialinspection");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "ReceiptVoucher");

            migrationBuilder.DropTable(
                name: "Purchasedetails");

            migrationBuilder.DropTable(
                name: "Inventoryreservation");

            migrationBuilder.DropTable(
                name: "IssueNoteheader");

            migrationBuilder.DropTable(
                name: "ReceivedEntry");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "PRDetails");

            migrationBuilder.DropTable(
                name: "PO");

            migrationBuilder.DropTable(
                name: "Bom");

            migrationBuilder.DropTable(
                name: "PR");

            migrationBuilder.DropTable(
                name: "PaymenttermsDays");

            migrationBuilder.DropTable(
                name: "PODeliveryTerms");

            migrationBuilder.DropTable(
                name: "POPaymentterms");

            migrationBuilder.DropTable(
                name: "Popaymentterms2");

            migrationBuilder.DropTable(
                name: "postatus");

            migrationBuilder.DropTable(
                name: "SupplierContact");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductionStages");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "PRstatus");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "SubCategory");

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
                name: "JobStage");

            migrationBuilder.DropTable(
                name: "JobType");

            migrationBuilder.DropTable(
                name: "ManufacturingBay");

            migrationBuilder.DropTable(
                name: "ProjectCategory");

            migrationBuilder.DropTable(
                name: "QualityLevel");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "BudgettHeader");
        }
    }
}
