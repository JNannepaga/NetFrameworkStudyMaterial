using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace EntityFramework.FluentAPI.OnetoOneMapping
{
    internal class GeneralCustomerEntityConfiguration : EntityTypeConfiguration<GeneralCustomer>
    {
        public GeneralCustomerEntityConfiguration()
        {
            this.ToTable("GeneralCustomer");

            #region Properties Mapping
            this.Property(gc => gc.Credits)
                .HasColumnName("Credits")
                .HasColumnType("MONEY");

            this.Property(gc => gc.NormalCoupon)
                .HasColumnName("NormalCoupon")
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);
            #endregion

            #region SP Mappings
            this.MapToStoredProcedures(p =>
               p.Insert(sp => sp.HasName("SP_GeneralCustomer_Insert")
                .Parameter(pm => pm.Credits, "Credits")
                .Parameter(pm => pm.NormalCoupon, "NormalCoupon")
                ));
            #endregion
        }
    }
}
