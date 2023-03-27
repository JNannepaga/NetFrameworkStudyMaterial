using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.FluentAPI.OnetoManyMapping
{
    public class OrderEntityConfig : EntityTypeConfiguration<Order>
    {
        public OrderEntityConfig()
        {
            this.ToTable("CustomerOrder")
                .HasKey(o => o.OrderId)
                .Ignore(o => o.ItemCost)
                .Ignore(o => o.TotalAmount);

            this.HasRequired<Customer>(o=>o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerRefId);

            this.HasMany<MenuItem>(o => o.MenuItems)
                .WithOptional(mi => mi.Order)
                .HasForeignKey(o => o.OrderRefId);

            #region Property Mapping
            this.Property(o => o.OrderId)
                .HasColumnName("OrderId")
                .HasColumnOrder(0)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(o => o.TaxAmount)
                .HasColumnName("TaxAmount")
                .HasColumnOrder(1)
                .HasColumnType("MONEY");

            this.Property(o => o.DeliveryCharge)
                .HasColumnName("DeliveryCharge")
                .HasColumnOrder(2)
                .HasColumnType("MONEY");

            this.Property(o => o.CustomerRefId)
                .HasColumnName("CustomerId")
                .HasColumnOrder(3)
                .HasColumnType("INT")
                .IsRequired();
            #endregion
        }
    }
}
