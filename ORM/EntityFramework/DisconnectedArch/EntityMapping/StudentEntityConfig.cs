using System.Data.Entity.ModelConfiguration;

namespace EntityFramework.DisconnectedArch
{
    internal class StudentEntityConfig : EntityTypeConfiguration<Student>
    {
        public StudentEntityConfig() 
        {
            #region Entity Mappings
            this.ToTable("Student")
                .HasKey(s => s.StudentID)
                .Ignore(s => s.FullName)
                .HasRequired(s => s.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.CourseRefId);

            #endregion

            #region Properties Mappings
            this.Property(s => s.StudentID)
                .HasColumnName("StudentID")
                .HasColumnOrder(0)
                .HasColumnType(constants.INT)
                .IsRequired();

            this.Property(s => s.FirstName)
                .HasColumnName("FirstName")
                .HasColumnOrder(1)
                .HasColumnType(constants.VARCHAR)
                .HasMaxLength(30)
                .IsRequired();

            this.Property(s => s.LastName)
                .HasColumnName("LastName")
                .HasColumnOrder(2)
                .HasColumnType(constants.VARCHAR)
                .HasMaxLength(30)
                .IsOptional();
            #endregion
        }
    }
}
