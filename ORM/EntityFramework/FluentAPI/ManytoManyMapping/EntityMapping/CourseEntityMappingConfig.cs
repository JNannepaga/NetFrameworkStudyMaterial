using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EntityFramework.FluentAPI.ManytoManyMapping
{
    internal class CourseEntityMappingConfig : EntityTypeConfiguration<Course>
    {
        public CourseEntityMappingConfig()
        {
            this.ToTable("Course")
                .HasKey(c => c.CourseId)
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .Map(m => m.ToTable("StudentCourse").MapLeftKey("CourseId").MapRightKey("StudentId")); ;

            this.Property(c => c.CourseId)
                .HasColumnName("CourseId")
                .HasColumnOrder(0)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(c => c.CourseName)
                .HasColumnName("CourseName")
                .HasColumnOrder(1)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            this.Property(c => c.Code)
                .HasColumnName("Code")
                .HasColumnOrder(2)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
        }
    }
}
