using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.FluentAPI.OnetoManyMapping
{
    internal class CustomerEntityConfig : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityConfig()
        {
            this.ToTable("Customer")
                .HasKey(c => c.CustomerId)
                .Ignore(c => c.FullName)
                .HasMany(c => c.Orders)
                .WithRequired(o => o.Customer)
                .HasForeignKey(c => c.CustomerRefId);

            #region Property Mapping
            this.Property(c => c.CustomerId)
                .HasColumnName("CustomerId")
                .HasColumnOrder(0)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.FirstName)
                .HasColumnName("FirstName")
                .HasColumnOrder(1)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.LastName)
                .HasColumnName("LastName")
                .HasColumnOrder(2)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsOptional();

            this.Property(c => c.Gender)
                .HasColumnName("Gender")
                .HasColumnOrder(3)
                .HasColumnType("INT")
                .IsOptional();

            #endregion
        }
    }
}
