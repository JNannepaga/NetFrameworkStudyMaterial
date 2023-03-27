using System;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.FluentAPI.OnetoManyMapping
{
    internal class MenuItemEntityConfig : EntityTypeConfiguration<MenuItem>
    {
        public MenuItemEntityConfig()
        {
            this.ToTable("MenuItem")
                .HasKey(mi => mi.ItemId)
                .HasOptional(mi => mi.Order);

            #region Property Config
            this.Property(mi => mi.ItemId)
                .HasColumnName("ItemId")
                .HasColumnOrder(0)
                .HasColumnType("INT")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(mi => mi.ItemName)
                .HasColumnName("ItemName")
                .HasColumnOrder(1)
                .HasColumnType("VARCHAR")
                .IsRequired();

            this.Property(mi => mi.Price)
                .HasColumnName("Price")
                .HasColumnOrder(2)
                .HasColumnType("MONEY")
                .IsOptional();

            this.Property(mi => mi.OrderRefId)
                .HasColumnName("OrderId")
                .HasColumnOrder(3)
                .HasColumnType("INT")
                .IsOptional();
            #endregion
        }
    }
}
