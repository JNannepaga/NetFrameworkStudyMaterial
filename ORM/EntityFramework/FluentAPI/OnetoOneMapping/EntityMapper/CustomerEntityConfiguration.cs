using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    internal class CustomerEntityConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerEntityConfiguration()
        {
            #region Configure Entity Mappings
            this.ToTable("Customer")
                .HasKey(c => c.CustomerId)//Primary Key
                .Ignore(c => c.FullName)
                .HasOptional(c => c.CustomerRequisites) //Optional
                .WithRequired(cr => cr.Customer);//Principal EndNode
            #endregion

            #region Configure Property Mappings
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
                .HasMaxLength(50);

            this.Property(c => c.Gender)
                .HasColumnName("Gender")
                .HasColumnOrder(3)
                .HasColumnType("INT")
                .IsOptional();

            #endregion

            #region SP Mappings
            this.MapToStoredProcedures(p => p.Insert(sp =>
                sp.HasName("SP_Customer_Insert")
                .Parameter(pm => pm.FirstName, "FirstName")
                .Parameter(pm => pm.LastName, "LastName")
                .Parameter(pm => pm.Gender, "Gender")
            ));
            #endregion
        }
    }
}
