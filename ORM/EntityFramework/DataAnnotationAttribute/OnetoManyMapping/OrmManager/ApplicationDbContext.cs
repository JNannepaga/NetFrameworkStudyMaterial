using System.Data.Entity;

namespace EntityFramework.DataAnnotationAttribute.OnetoManyMapping.OrmManager
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name = EF_DAA_One_Many_Mapping")
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseAlways<DbContext>());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
