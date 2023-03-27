using System.Data.Entity;

namespace EntityFramework.FluentAPI.ManytoManyMapping.OrmManager
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name = EF_FAPI_Many_Many_Mapping")
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseAlways<DbContext>());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentEntityMapppingConfig());
            modelBuilder.Configurations.Add(new CourseEntityMappingConfig());
        }
    }
}
