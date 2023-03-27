using System;
using System.Data.Entity;


namespace EntityFramework.TPH
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
            : base("name = TPH")
        {
            Database.SetInitializer<ApplicationDBContext>(
                new DropCreateDatabaseAlways<ApplicationDBContext>());
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
