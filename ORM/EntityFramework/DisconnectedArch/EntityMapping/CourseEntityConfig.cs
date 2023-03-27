using System.Data.Entity.ModelConfiguration;

namespace EntityFramework.DisconnectedArch
{
    internal class CourseEntityConfig : EntityTypeConfiguration<Course>
    {
        public CourseEntityConfig()
        {
            #region Entity Mappings
            this.ToTable("Course")
                .HasKey(c => c.CourseId)
                .HasMany(c => c.Students)
                .WithRequired(s => s.Course)
                .HasForeignKey(c => c.CourseRefId);
                
            #endregion

            #region Properties Mappings
            this.Property(c => c.CourseId)
                .HasColumnName("CourseId")
                .HasColumnOrder(0)
                .HasColumnType(constants.INT)
                .IsRequired();

            this.Property(c => c.CourseName)
                .HasColumnName("CourseName")
                .HasColumnOrder(1)
                .HasColumnType(constants.VARCHAR)
                .HasMaxLength(30);
            #endregion
        }
    }
}
