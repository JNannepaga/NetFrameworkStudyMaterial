using System.Data.Entity.ModelConfiguration;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    internal class CatelogEntityConfiguration : EntityTypeConfiguration<Catelog>
    {
        public CatelogEntityConfiguration()
        {
            this.ToTable("Catelog")
                .HasKey(c => c.CatelogId)
                .HasRequired(c => c.RegularCustomer)
                .WithOptional(rc => rc.Catelog);

            #region Property Mappings
            this.Property(c => c.CatelogId)
                .HasColumnName("CatelogId")
                .HasColumnOrder(0)
                .HasColumnType("INT");

            this.Property(c => c.CatelogName)
                .HasColumnName("CatelogName")
                .HasColumnType("VARCHAR")
                .HasColumnOrder(1)
                .HasMaxLength(25);

            this.Property(c => c.CatelogPassword)
                .HasColumnName("CatelogPassword")
                .HasColumnType("VARCHAR")
                .HasColumnOrder(2)
                .HasMaxLength(25);

            this.Property(c => c.isActive)
                .HasColumnName("isActivated")
                .HasColumnType("BIT")
                .HasColumnOrder(3);
            #endregion

            #region SP Mappings
            this.MapToStoredProcedures(p => 
               p.Insert(sp => sp.HasName("SP_CustomerCateloges_Insert")
                .Parameter(pm => pm.CatelogName, "CatelogName")
                .Parameter(pm => pm.CatelogPassword, "CatelogPassword")
                .Parameter(pm => pm.isActive, "isActivated")
            ));
            #endregion
        }
    }
}
