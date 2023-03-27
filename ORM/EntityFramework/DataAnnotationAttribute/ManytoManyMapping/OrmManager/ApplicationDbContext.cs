using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;

namespace EntityFramework.DataAnnotationAttribute.ManytoManyMapping.OrmManager
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name = EF_DAA_Many_Many_Mapping")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<
                EntityFramework.DataAnnotationAttribute.ManytoManyMapping.OrmManager.ApplicationDbContext,
                EntityFramework.Migrations.Configuration>()
                );
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //DbInterception.Add();
            base.OnModelCreating(modelBuilder);
        }
    }
}
