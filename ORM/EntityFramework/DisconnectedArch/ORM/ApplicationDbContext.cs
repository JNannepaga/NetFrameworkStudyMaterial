using System.Data.Entity;


namespace EntityFramework.DisconnectedArch.ORM
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name = DiscArch")
        {

        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentEntityConfig());
            modelBuilder.Configurations.Add(new CourseEntityConfig());
        }
    }
}
