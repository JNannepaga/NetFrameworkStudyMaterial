using System.Data.Entity;

namespace EntityFramework.DataAnnotationAttribute.OnetoOneMapping.OrmManager
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name = EF_DAA_One_One_Mapping")
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseAlways<DbContext>());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<RegularCustomer> RegularCustomers { get; set; }
        public DbSet<GeneralCustomer> GeneralCustomers { get; set; }
        public DbSet<Catelog> Catelogs { get; set; }
        public DbSet<CustomerRequisite> CustomerRequisites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<RegularCustomer>()
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("SP_RegularCustomer_Insert")
                                             .Parameter(pm => pm.FirstName, "FirstName")
                                             .Parameter(pm => pm.LastName, "LastName")
                                             .Parameter(pm => pm.Gender, "Gender")
                                             .Parameter(pm => pm.AdvCredits, "AdvCredits")
                                             .Parameter(pm => pm.Perks, "Perks")
                ));

            modelBuilder.Entity<CustomerRequisite>()
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("SP_CustomerRequisite_Insert")
                                             .Parameter(pm => pm.Mobile, "MobileNum")
                                             .Parameter(pm => pm.IdProofType, "IdProofType")
                                             .Parameter(pm => pm.IdProof, "IdProof")
                ));

            modelBuilder.Entity<Catelog>()
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("SP_CustomerCateloges_Insert")
                                             .Parameter(pm => pm.CatelogName, "CatelogName")
                                             .Parameter(pm => pm.CatelogPassword, "CatelogPassword")
                                             .Parameter(pm => pm.isActive, "isActivated")
                ));

            return;
        }
    }
}
