using System.Data.Entity.ModelConfiguration;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    internal class CustomerRequisiteEntityConfigurations : EntityTypeConfiguration<CustomerRequisite>
    {
        public CustomerRequisiteEntityConfigurations()
        {
            #region Entity Mappings
            this.ToTable("CustomerRequisite")
                .HasKey(cr => cr.CustomerRequisiteId)
                .HasRequired(cr => cr.Customer)
                .WithOptional(c => c.CustomerRequisites);
            #endregion

            #region Property Mappings
            this.Property(cr => cr.CustomerRequisiteId)
                .HasColumnName("CustomerId")
                .HasColumnOrder(0)
                .HasColumnType("INT");

            this.Property(cr => cr.Mobile)
                .HasColumnName("MobileNum")
                .HasColumnOrder(1)
                .HasColumnType("VARCHAR")
                .HasMaxLength(10)
                .IsRequired();

            this.Property(cr => cr.IdProofType)
                .HasColumnName("IdProofType")
                .HasColumnOrder(2)
                .HasColumnType("INT")
                .IsOptional();

            this.Property(cr => cr.IdProof)
                .HasColumnName("IdProof")
                .HasColumnOrder(3)
                .HasColumnType("VARCHAR")
                .HasMaxLength(25);
            #endregion

            #region SP Mappings
            this.MapToStoredProcedures(p => 
                p.Insert(sp => sp.HasName("SP_CustomerRequisite_Insert")
                 .Parameter(pm => pm.Mobile, "MobileNum")
                 .Parameter(pm => pm.IdProofType, "IdProofType")
                 .Parameter(pm => pm.IdProof, "IdProof")
                ));
            #endregion
        }
    }
}
