using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
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


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.passcode).HasMaxLength(100); // Example configuration
            });




        }
    }
}
