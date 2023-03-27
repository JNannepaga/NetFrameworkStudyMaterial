using System.Data.Entity;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name = EF_FAPI_One_One_Mapping")
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseAlways<DbContext>());
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerRequisite> CustomerRequisites { get; set; }
        public virtual DbSet<GeneralCustomer> GeneralCustomers { get; set; }
        public virtual DbSet<RegularCustomer> RegularCustomers { get; set; }
        public virtual DbSet<Catelog> Catelogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerEntityConfiguration());
            modelBuilder.Configurations.Add(new CustomerRequisiteEntityConfigurations());
            modelBuilder.Configurations.Add(new GeneralCustomerEntityConfiguration());
            modelBuilder.Configurations.Add(new RegularCustomerEntityConfiguration());
            modelBuilder.Configurations.Add(new CatelogEntityConfiguration());
        }
    }
}
