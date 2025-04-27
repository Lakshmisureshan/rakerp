using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebApplication1.Models;
using WebApplication1.Models.Domain;
namespace WebApplication1.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<JobType> JobType { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<ManufacturingBay> ManufacturingBay { get; set; }
        public DbSet<ProjectCategory> ProjectCategory { get; set; }
        public DbSet<IsLDApplicable> IsLDApplicable { get; set; }
        

        public DbSet<QualityLevel> QualityLevel { get; set; }

        public DbSet<Currency> Currency { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UOM> UOM { get; set; }

        public DbSet<Warehouse> Warehouse { get; set; }
        public  DbSet<BudgettHeader> BudgettHeader { get; set; }
        public DbSet<ProductionStages> ProductionStages { get; set; }
        public DbSet<Bom> Bom { get; set; }
        public DbSet<PR> PR { get; set; }
        public DbSet<PRDetails> PRDetails { get; set; }
        public DbSet<PRstatus> PRstatus { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Popaymentterms2> Popaymentterms2 { get; set; }
        public DbSet<PO> PO { get; set; }

        public DbSet<SupplierContact> SupplierContact { get; set; }

        public DbSet<POPaymentterms> POPaymentterms { get; set; }

        public DbSet<PODeliveryTerms> PODeliveryTerms { get; set; }
        public DbSet<PaymenttermsDays> PaymenttermsDays { get; set; }
        public DbSet<Purchasedetails> Purchasedetails { get; set; }
        public DbSet<PRPO> PRPO { get; set; }
        public DbSet<POStatus> postatus { get; set; }
        public DbSet<ReceivedEntry> ReceivedEntry { get; set; }
        public DbSet<GRNHeader> GRNHeader { get; set; }
        public DbSet<ReceivedEntryDetails> ReceivedEntryDetails { get; set; }
        public DbSet<GRNDetails> GRNDetails { get; set; }

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<IssueNoteheader> IssueNoteheader { get; set; }
        public DbSet<Issuenotedetails> Issuenotedetails { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<Inventoryreservation> Inventoryreservation { get; set; }

        public DbSet<grntracking> grntracking { get; set; }


        public DbSet<Issuetracking> Issuetracking { get; set; }
        public DbSet<IssuedetailsfromStock> IssuedetailsfromStock { get; set; }

        public DbSet<Issuereturn> Issuereturn { get; set; }

        


        public DbSet<Issuereturndetails> Issuereturndetails { get; set; }


  public DbSet<BaseCurrency> BaseCurrency { get; set; }

        public DbSet<issuereturntracking> issuereturntracking { get; set; }


        public DbSet<SubCategory> SubCategory { get; set; }

        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Invoicedetails> Invoicedetails { get; set; }

        public DbSet<InvoiceReg> InvoiceReg { get; set; }

        public DbSet<FixedBudget> FixedBudget { get; set; }

        public DbSet<estimation> estimation { get; set; }

        public DbSet<Materialinspection> Materialinspection { get; set; }

        public DbSet<MIdetails> MIdetails { get; set; }

        public DbSet<JobStage> JobStage { get; set; }

        public DbSet<Miscost> Miscost { get; set; }
        public DbSet<ReceiptVoucher> ReceiptVoucher { get; set; }
        public DbSet<receipt> receipt { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            var readRoleID = "e76b0657-67f3-4e84-9320-1ed68a80a8f5";
            var writeRoleID = "9ab357a2-67a2-4be8-82fd-12339553dd8b";
            var financemanagerRoleID = "72c35b91-4022-4c2b-adc3-1ec004c08a21";
            var trademanagerRoleID = "3c8cdf22-752c-446a-bb42-9bea05872bd5";
            var tradeuserRoleID = "b52de381-7ff6-4d7f-a385-51fa28f43aaa";
            var poverificationrole = "5e648847-b462-464d-8e1e-aa20a7947bef";
            var poauthorizationrole = "333559dc-c729-403c-a80e-77250b8a0592";
            var grnregistrationrole = "e05d3da2-24c8-43fb-859f-cdbee6ac2a73";

            var prverificationrole = "0eae39be-0cd2-4e99-a8c6-8258c72dc7ad";
            var miscostcreationrole = "b65fb755-5a86-46a7-b28d-8e935c05b967";

            var roles = new List<IdentityRole>
{
 new IdentityRole ()
{
Id =readRoleID,
Name ="Reader",
NormalizedName ="Reader".ToUpper(),
ConcurrencyStamp =readRoleID
},
 new IdentityRole ()
{
Id =writeRoleID,
Name ="Writer",
NormalizedName ="Writer".ToUpper(),
ConcurrencyStamp =writeRoleID
},

 new IdentityRole ()
{
Id =financemanagerRoleID,
Name ="FinanceManager",
NormalizedName ="FinanceManager".ToUpper(),
ConcurrencyStamp =financemanagerRoleID
},


 new IdentityRole ()
{
Id =trademanagerRoleID,
Name ="TradeManager",
NormalizedName ="TradeManager".ToUpper(),
ConcurrencyStamp =trademanagerRoleID
},


  new IdentityRole ()
{
Id =tradeuserRoleID,
Name ="TradeUser",
NormalizedName ="TradeUser".ToUpper(),
ConcurrencyStamp =tradeuserRoleID
},

  new IdentityRole ()
{
Id =poverificationrole,
Name ="POVerification",
NormalizedName ="POVerification".ToUpper(),
ConcurrencyStamp =poverificationrole
},

  new IdentityRole ()
{
Id =poauthorizationrole,
Name ="POAuthorization",
NormalizedName ="POAuthorization".ToUpper(),
ConcurrencyStamp =poauthorizationrole
},

  


    new IdentityRole ()
{
Id =grnregistrationrole,
Name ="GRNRegistration",
NormalizedName ="GRNRegistration".ToUpper(),
ConcurrencyStamp =grnregistrationrole
},



  new IdentityRole ()
{
Id =prverificationrole,
Name ="PRVerification",
NormalizedName ="PRVerification".ToUpper(),
ConcurrencyStamp =prverificationrole
},

  new IdentityRole ()
{
Id =miscostcreationrole,
Name ="Miscostcreation",
NormalizedName ="Miscostcreation".ToUpper(),
ConcurrencyStamp =miscostcreationrole
},





};
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            var adminUserid = "356ff228-0e5f-436a-9ac5-2d760b997dd5";
            //create admin user
            var admin = new ApplicationUser
            {
                Id = adminUserid,
                UserName = "admin@trading.com",
                Email = "admin@trading.com",
                NormalizedEmail = "admin@trading.com".ToUpper(),
                NormalizedUserName = "admin@trading.com".ToUpper(),
                passcode ="123456"
            };
            admin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(admin, "Admin@123");
            modelBuilder.Entity<ApplicationUser>().HasData(admin);
            //give roles to admin user
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserid,
                    RoleId  = readRoleID
                },
                new()
                {
                    UserId = adminUserid,
                    RoleId  = writeRoleID

                },

                 new()
                {
                    UserId = adminUserid,
                    RoleId  = financemanagerRoleID

                },
                  new()
                {
                    UserId = adminUserid,
                    RoleId  = trademanagerRoleID

                },

               new()
                {
                    UserId = adminUserid,
                    RoleId  = tradeuserRoleID

                },


               new()
                {
                    UserId = adminUserid,
                    RoleId  = poverificationrole

                },
                new()
                {
                    UserId = adminUserid,
                    RoleId  = poauthorizationrole

                },
                  new()
                {
                    UserId = adminUserid,
                    RoleId  = grnregistrationrole

                }


                  ,
                  new()
                {
                    UserId = adminUserid,
                    RoleId  = prverificationrole

                },
                     new()
                {
                    UserId = adminUserid,
                    RoleId  = miscostcreationrole

                }

            };

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminRoles);



























            modelBuilder.Entity<Customer>()
            .HasOne(pd => pd.country)
            .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            .HasForeignKey(pd => pd.countryid)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Job>()
                 .HasOne(pd => pd.JobType)
                 .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                 .HasForeignKey(pd => pd.jobtypeid)
                 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Job>()
                 .HasOne(pd => pd.ProjectManager)
                 .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                 .HasForeignKey(pd => pd.projectmanagerid)
                 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
             .HasOne(pd => pd.ProjectEngineer)
             .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
             .HasForeignKey(pd => pd.projectengineerid)
             .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Job>()
            .HasOne(pd => pd.ManufacturingBay)
            .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            .HasForeignKey(pd => pd.manufacturingbayid)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<estimation>()
         .HasOne(pd => pd.Job)
         .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
         .HasForeignKey(pd => pd.jobid)
         .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
            .HasOne(pd => pd.QualityLevel)
            .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            .HasForeignKey(pd => pd.qualitylevelid)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Job>()
            .HasOne(pd => pd.ProjectCategory)
            .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            .HasForeignKey(pd => pd.projectcategoryid)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Job>()
           .HasOne(pd => pd.Currency)
           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
           .HasForeignKey(pd => pd.currencyid)
           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
           .HasOne(pd => pd.isldapp)
           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
           .HasForeignKey(pd => pd.isldapplicable)
           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Inventory>()
         .HasOne(pd => pd.PO)
         .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
         .HasForeignKey(pd => pd.pono)
         .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Inventory>()
      .HasOne(pd => pd.Job)
      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
      .HasForeignKey(pd => pd.jobid)
      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


    modelBuilder.Entity<Inventory>()
   .HasOne(pd => pd.Job)
   .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
   .HasForeignKey(pd => pd.jobid)
   .OnDelete(DeleteBehavior.NoAction);
    base.OnModelCreating(modelBuilder);


 modelBuilder.Entity<Inventory>()
.HasOne(pd => pd.Product)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.productid)
.OnDelete(DeleteBehavior.NoAction);
base.OnModelCreating(modelBuilder);



modelBuilder.Entity<Inventory>()
.HasOne(pd => pd.UOM)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.uomid)
.OnDelete(DeleteBehavior.NoAction);
base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Job>()
        .HasOne(pd => pd.Enduser)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.enduserid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UomMultiplyingFactor>()
      .HasOne(pd => pd.Product)
      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
      .HasForeignKey(pd => pd.itemid)
      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UomMultiplyingFactor>()
                .HasOne(pd => pd.Product)
                .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                .HasForeignKey(pd => pd.itemid)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<UomMultiplyingFactor>()
              .HasOne(pd => pd.FROMUOM)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.fromuomid)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UomMultiplyingFactor>()
            .HasOne(pd => pd.TOUOM)
            .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            .HasForeignKey(pd => pd.touomid)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
        .HasOne(pd => pd.UOM)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.standarduomid )
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Bom>()
         .HasOne(pd => pd.Product)
         .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
         .HasForeignKey(pd => pd.itemid)
         .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Bom>()
                 .HasOne(pd => pd.UOM)
                 .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                 .HasForeignKey(pd => pd.bomuomid)
                 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bom>()
               .HasOne(pd => pd.Productionstages)
               .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
               .HasForeignKey(pd => pd.prodstageid)
               .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bom>()
            .HasOne(pd => pd.currency)
            .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            .HasForeignKey(pd => pd.currencyid)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bom>()
        .HasOne(pd => pd.Job)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.jobid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);









            modelBuilder.Entity<PR>()
               .HasOne(pd => pd.Job)
               .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
               .HasForeignKey(pd => pd.jobid)
               .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<PRDetails>()
                    .HasOne(pd => pd.PR)
                    .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                    .HasForeignKey(pd => pd.prid)
                    .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PRDetails>()
               .HasOne(pd => pd.Product)
               .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
               .HasForeignKey(pd => pd.pritemid)
               .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PRDetails>()
                       .HasOne(pd => pd.Bom)
                       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                       .HasForeignKey(pd => pd.bomid)
                       .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                    .HasOne(pd => pd.BudgettHeader)
                    .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                    .HasForeignKey(pd => pd.itembudgetheaderid)
                    .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PR>()
               .HasOne(pd => pd.verifiedby)
               .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
               .HasForeignKey(pd => pd.verifiedbyid)
               .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PR>()
                       .HasOne(pd => pd.prcreatedby)
                       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                       .HasForeignKey(pd => pd.prcreatedbyid)
                       .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<PR>()
                     .HasOne(pd => pd.PRstatus)
                     .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                     .HasForeignKey(pd => pd.prstatusid)
                     .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Bom>()
                   .HasOne(pd => pd.Bomcreatedby)
                   .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                   .HasForeignKey(pd => pd.bomcreatedbyid)
                   .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PO>()
             .HasOne(pd => pd.Job)
             .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
             .HasForeignKey(pd => pd.jobid)
             .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PO>()
           .HasOne(pd => pd.createdby)
           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
           .HasForeignKey(pd => pd.createdbyid)
           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<PO>()
       .HasOne(pd => pd.modifiedby)
       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
       .HasForeignKey(pd => pd.modifiedbyid)
       .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<GRNDetails>()
              .HasOne(pd => pd.Product)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.itemcode)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<GRNDetails>()
              .HasOne(pd => pd.GRNHeader)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.grnno)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<GRNDetails>()
                  .HasOne(pd => pd.POUOM)
                  .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                  .HasForeignKey(pd => pd.pouomid)
                  .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<GRNDetails>()
              .HasOne(pd => pd.Inventoryuom)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.inventoryuomid)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PRDetails>()
          .HasOne(pd => pd.UOM)
          .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
          .HasForeignKey(pd => pd.pruomid)
          .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<IssueNoteheader>()
      .HasOne(pd => pd.job)
      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
      .HasForeignKey(pd => pd.jobid)
      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Issuenotedetails>()
                 .HasOne(pd => pd.Product)
                 .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                 .HasForeignKey(pd => pd.itemid)
                 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Issuenotedetails>()
              .HasOne(pd => pd.IssueNoteheader)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.issuenoteref)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




         










            modelBuilder.Entity<PO>()
    .HasOne(pd => pd.Poverifiedby)
    .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
    .HasForeignKey(pd => pd.poverifiedbyid)
    .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PO>()
               .HasOne(pd => pd.PoAuthorizedby)
               .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
               .HasForeignKey(pd => pd.PoAuthorizedbyid)
               .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);






            modelBuilder.Entity<PO>()
           .HasOne(pd => pd.SupplierContact)
           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
           .HasForeignKey(pd => pd.suppliercontactid)
           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReceivedEntryDetails>()
          .HasOne(pd => pd.ReceivedEntry)
          .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
          .HasForeignKey(pd => pd.RENO)
          .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<ReceivedEntryDetails>()
        .HasOne(pd => pd.ReceivedEntry)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.RENO)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ReceivedEntryDetails>()
   .HasOne(pd => pd.Product)
   .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
   .HasForeignKey(pd => pd.itemid)
   .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<GRNHeader>()
.HasOne(pd => pd.PO)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.pono)
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<ReceivedEntryDetails>()
       .HasOne(pd => pd.Purchasedetails)
       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
       .HasForeignKey(pd => pd.potblid)
       .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Purchasedetails>()
      .HasOne(pd => pd.UOM)
      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
      .HasForeignKey(pd => pd.pouomid)
      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            





     modelBuilder.Entity<Issuereturndetails>()
      .HasOne(pd => pd.Issuereturn)
      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
      .HasForeignKey(pd => pd.issuereturnref)
      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Issuereturndetails>()
     .HasOne(pd => pd.Product)
     .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
     .HasForeignKey(pd => pd.productid)
     .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Issuereturndetails>()
  .HasOne(pd => pd.IssuedetailsfromStock)
  .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
  .HasForeignKey(pd => pd.issuedetailtblid)
  .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<PRDetails>()
        .HasMany(pr => pr.Purchasedetails)
        .WithMany(pd => pd.prdetails)
        .UsingEntity<PRPO>(
            j => j
                .HasOne(prpo => prpo.Purchasedetails)
                .WithMany(pd => pd.PRPOs)
                .HasForeignKey(prpo => prpo.Purchasedetailspotblid),
            j => j
                .HasOne(prpo => prpo.Prdetails)
                .WithMany(pr => pr.PRPOs)
                .HasForeignKey(prpo => prpo.prdetailsprtblid),
            j =>
            {
                j.ToTable("PRPO");
            });
        

























        modelBuilder.Entity<Purchasedetails>()
            .HasOne(pd => pd.PO)
            .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            .HasForeignKey(pd => pd.orderid)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Purchasedetails>()
        .HasOne(pd => pd.product)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.poitemid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<PO>()
     .HasOne(pd => pd.Supplier)
     .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
     .HasForeignKey(pd => pd.supplierid)
     .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<PO>()
.HasOne(pd => pd.POPaymentterms2)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.POPaymentterms2id)
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<Inventory>()
.HasOne(pd => pd.Currency)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.invcurrencyid)
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);












            modelBuilder.Entity<SupplierContact>()
.HasOne(pd => pd.Supplier)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.supplierid)
.OnDelete(DeleteBehavior.NoAction);
 base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>()
          .HasOne(pd => pd.BudgettHeader)
          .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
          .HasForeignKey(pd => pd.budgetheaderid)
          .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);






            modelBuilder.Entity<SubCategory>()
         .HasOne(pd => pd.Category)
         .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
         .HasForeignKey(pd => pd.categoryid)
         .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);










            modelBuilder.Entity<ReceivedEntry>()
                  .HasOne(pd => pd.PO)
                  .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                  .HasForeignKey(pd => pd.pono)
                  .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Product>()
        .HasOne(pd => pd.Category)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.categoryid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
      .HasOne(pd => pd.SubCategory)
      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
      .HasForeignKey(pd => pd.subcategoryid)
      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Inventoryreservation>()
       .HasOne(pd => pd.Product)
       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
       .HasForeignKey(pd => pd.productid)
       .OnDelete(DeleteBehavior.NoAction);
       base.OnModelCreating(modelBuilder);


       modelBuilder.Entity<Inventoryreservation>()
      .HasOne(pd => pd.FROMJob)
      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
      .HasForeignKey(pd => pd.fromjobid)
      .OnDelete(DeleteBehavior.NoAction);
       base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inventoryreservation>()
                .HasOne(pd => pd.TOJob)
                .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                .HasForeignKey(pd => pd.tojobid)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inventoryreservation>()
              .HasOne(pd => pd.Inventory)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.inventoryid)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inventoryreservation>()
         .HasOne(pd => pd.UOM)
         .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
         .HasForeignKey(pd => pd.uomid)
         .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Inventoryreservation>()
        .HasOne(pd => pd.PRDetails)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.prtblid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Inventoryreservation>()
    .HasOne(pd => pd.Currency)
    .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
    .HasForeignKey(pd => pd.invrcurrencyid)
    .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);





















            //      modelBuilder.Entity<grntracking>()
            //.HasOne(pd => pd.Inventory)
            //.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            //.HasForeignKey(pd => pd.invid)
            //.OnDelete(DeleteBehavior.NoAction);
            //      base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<grntracking>()
 .HasOne(pd => pd.Job)
 .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
 .HasForeignKey(pd => pd.jobid)
 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<grntracking>()
        .HasOne(pd => pd.GRNHeader)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.grnno)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<grntracking>()
   .HasOne(pd => pd.Product)
   .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
   .HasForeignKey(pd => pd.productid)
   .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<grntracking>()
   .HasOne(pd => pd.UOM)
   .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
   .HasForeignKey(pd => pd.grnuomid)
   .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<grntracking>()
              .HasOne(pd => pd.currency)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.grncurrencyid)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

















            //            modelBuilder.Entity<Issuetracking>()
            //.HasOne(pd => pd.Inventory)
            //.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
            //.HasForeignKey(pd => pd.invid)
            //.OnDelete(DeleteBehavior.NoAction);
            //            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Issuetracking>()
 .HasOne(pd => pd.Job)
 .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
 .HasForeignKey(pd => pd.jobid)
 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Issuetracking>()
        .HasOne(pd => pd.IssueNoteheader)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.issuenoteno)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Issuetracking>()
   .HasOne(pd => pd.Product)
   .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
   .HasForeignKey(pd => pd.productid)
   .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Issuetracking>()
.HasOne(pd => pd.UOM)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.issueuomid)
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Issuetracking>()
.HasOne(pd => pd.currency)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.issuecurrencyid)
.OnDelete(DeleteBehavior.NoAction);
  base.OnModelCreating(modelBuilder);

  



            modelBuilder.Entity<issuereturntracking>()
              .HasOne(pd => pd.Job)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.jobid)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<issuereturntracking>()
             .HasOne(pd => pd.Issuereturn)
             .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
             .HasForeignKey(pd => pd.issuereturnno)
             .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<issuereturntracking>()
             .HasOne(pd => pd.Product)
             .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
             .HasForeignKey(pd => pd.productid)
             .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);







            modelBuilder.Entity<issuereturntracking>()
          .HasOne(pd => pd.currency)
          .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
          .HasForeignKey(pd => pd.issuecurrencyid)
          .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<issuereturntracking>()
        .HasOne(pd => pd.UOM)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.uomid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<IssuedetailsfromStock>()
             .HasOne(pd => pd.IssueNoteheader)
             .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
             .HasForeignKey(pd => pd.issuenoteref)
             .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<IssuedetailsfromStock>()
                       .HasOne(pd => pd.Product)
                       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                       .HasForeignKey(pd => pd.itemid)
                       .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<IssuedetailsfromStock>()
                       .HasOne(pd => pd.Inventoryreservation)
                       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                       .HasForeignKey(pd => pd.rid)
                       .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IssuedetailsfromStock>()
                      .HasOne(pd => pd.Currency)
                      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                      .HasForeignKey(pd => pd.issuecurrencyid)
                      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<IssuedetailsfromStock>()
                    .HasOne(pd => pd.UOM)
                    .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                    .HasForeignKey(pd => pd.issueuomid)
                    .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);








            modelBuilder.Entity<Issuereturn>()
                       .HasOne(pd => pd.job)
                       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                       .HasForeignKey(pd => pd.jobid)
                       .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Issuereturndetails>()
                    .HasOne(pd => pd.Currency)
                    .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                    .HasForeignKey(pd => pd.ircurrencyid)
                    .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Issuereturndetails>()
                   .HasOne(pd => pd.UOM)
                   .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                   .HasForeignKey(pd => pd.iruomid)
                   .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Invoice>()
                 .HasOne(pd => pd.Job)
                 .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                 .HasForeignKey(pd => pd.jobid)
                 .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Invoice>()
                           .HasOne(pd => pd.Currency)
                           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                           .HasForeignKey(pd => pd.invcurrencyid)
                           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>()
                        .HasOne(pd => pd.Customer)
                        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                        .HasForeignKey(pd => pd.customerid)
                        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Invoicedetails>()
                      .HasOne(pd => pd.Invoice)
                      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                      .HasForeignKey(pd => pd.invoiceno)
                      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<FixedBudget>()
                      .HasOne(pd => pd.BudgetHeader)
                      .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                      .HasForeignKey(pd => pd.budgetId)
                      .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<InvoiceReg>()
        .HasOne(pd => pd.Invoice)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.invoiceno)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<InvoiceReg>()
        .HasOne(pd => pd.Job)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.jobid )
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Miscost>()
                               .HasOne(pd => pd.Job)
                               .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                               .HasForeignKey(pd => pd.jobid)
                               .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<InvoiceReg>()
        .HasOne(pd => pd.applicationUser)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.Invoiceregisteredby)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<receipt>()
       .HasOne(pd => pd.receiptvoucher)
       .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
       .HasForeignKey(pd => pd.receiptid)
       .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<receipt>()
                  .HasOne(pd => pd.Invoice)
                  .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                  .HasForeignKey(pd => pd.invoiceid)
                  .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<receipt>()
                .HasOne(pd => pd.Customer)
                .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
                .HasForeignKey(pd => pd.customerid)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<receipt>()
              .HasOne(pd => pd.CreatedBy)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.Createdbyid)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<InvoiceReg>()
        .HasOne(pd => pd.Customer)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.customerid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<InvoiceReg>()
        .HasOne(pd => pd.Currency)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.currencyid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<MIdetails>()
           .HasOne(pd => pd.Materialinspection)
           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
           .HasForeignKey(pd => pd.mid)
           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<MIdetails>()
           .HasOne(pd => pd.Product)
           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
           .HasForeignKey(pd => pd.itemid)
           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



                        modelBuilder.Entity<estimation>()
  .HasOne(pd => pd.Currency)
  .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
  .HasForeignKey(pd => pd.currencyid)
  .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<estimation>()
.HasOne(pd => pd.Job)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.jobid)
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<estimation>()
.HasOne(pd => pd.ProductionStages)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.applicationid)
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<estimation>()
.HasOne(pd => pd.Product)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.itemid )
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<estimation>()
.HasOne(pd => pd.UOM)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.uomid)
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


       



            modelBuilder.Entity<ReceiptVoucher>()
.HasOne(pd => pd.Customer)
.WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
.HasForeignKey(pd => pd.customerid)
.OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReceiptVoucher>()
           .HasOne(pd => pd.Currency)
           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
           .HasForeignKey(pd => pd.rvcurrencyid)
           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReceiptVoucher>()
              .HasOne(pd => pd.createdby)
              .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
              .HasForeignKey(pd => pd.createdbyid)
              .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);





            modelBuilder.Entity<Job>()
     .HasOne(pd => pd.JobStage)
     .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
     .HasForeignKey(pd => pd.jobstageid)
     .OnDelete(DeleteBehavior.NoAction);
      base.OnModelCreating(modelBuilder);


















            modelBuilder.Entity<Materialinspection>()
           .HasOne(pd => pd.PO)
           .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
           .HasForeignKey(pd => pd.pono)
           .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Materialinspection>()
         .HasOne(pd => pd.receivedEntry)
         .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
         .HasForeignKey(pd => pd.reid)
         .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




















































            modelBuilder.Entity<InvoiceReg>()
        .HasOne(pd => pd.Job)
        .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
        .HasForeignKey(pd => pd.jobid)
        .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);




            modelBuilder.Entity<Job>()
      .Property(j => j.qualitylevelid)
 
      .IsRequired(false); // Explicitly allow NULL

            modelBuilder.Entity<Job>()
                .Property(j => j.projectcategoryid)
                .IsRequired(false);



















            modelBuilder.Entity<PO>()
  .HasOne(pd => pd.Currency)
  .WithMany() // Assuming a one-to-many relationship fro       m PRDetails to ItemMaster
  .HasForeignKey(pd => pd.pocurrencyid)
  .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.passcode).HasMaxLength(100); // Example configuration
            });




        }
    }
}
