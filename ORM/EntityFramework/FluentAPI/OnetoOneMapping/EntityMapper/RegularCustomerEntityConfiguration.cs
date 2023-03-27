using System.Data.Entity.ModelConfiguration;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    internal class RegularCustomerEntityConfiguration : EntityTypeConfiguration<RegularCustomer>
    {
        public RegularCustomerEntityConfiguration()
        {
            this.ToTable("RegularCustomer")
                .HasOptional(rc => rc.Catelog)
                .WithRequired(c => c.RegularCustomer);

            #region Property Configurations
            this.Property(rc => rc.AdvCredits)
                .HasColumnName("AdvCredits")
                .HasColumnOrder(1)
                .HasColumnType("MONEY");

            this.Property(rc => rc.Perks)
                .HasColumnName("Perks")
                .HasColumnOrder(2)
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);
            #endregion

            #region SP Mappings
            this.MapToStoredProcedures(p =>
               p.Insert(sp => sp.HasName("SP_RegularCustomer_Insert")
                .Parameter(pm => pm.AdvCredits, "AdvCredits")
                .Parameter(pm => pm.Perks, "Perks")
                ));
            #endregion
        }
    }
}
