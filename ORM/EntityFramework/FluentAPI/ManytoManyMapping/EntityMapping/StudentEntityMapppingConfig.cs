using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EntityFramework.FluentAPI.ManytoManyMapping
{
    internal class StudentEntityMapppingConfig : EntityTypeConfiguration<Student>
    {
        public StudentEntityMapppingConfig()
        {
            this.ToTable("Student")
                .HasKey(s => s.StudentId)
                .Ignore(s => s.FullName)
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .Map(m => m.ToTable("StudentCourse").MapLeftKey("StudentId").MapRightKey("CourseId")); 

            this.Property(s => s.StudentId)
                .HasColumnName("StudentId")
                .HasColumnOrder(0)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(s => s.FirstName)
                .HasColumnName("FirstName")
                .HasColumnOrder(1)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(s => s.LastName)
                .HasColumnName("LastName")
                .HasColumnOrder(2)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsOptional();

        }
    }
}
