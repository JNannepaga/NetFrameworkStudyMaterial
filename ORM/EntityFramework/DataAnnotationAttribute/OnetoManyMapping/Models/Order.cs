using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.DataAnnotationAttribute.OnetoManyMapping
{
    [Table("CustomerOrder")]
    public class Order
    {
        //Scalar Properties
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OrderId", Order = 0, TypeName = "INT")]
        public int OrderId { get; set; }
        
        [Column("TaxAmount", Order = 1, TypeName = "MONEY")]
        public decimal TaxAmount { get; set; }
        
        [Column("DeliveryCharge", Order = 2, TypeName = "MONEY")]
        public decimal DeliveryCharge { get; set; }
        
        [NotMapped]
        public decimal ItemCost {
            get
            {
                decimal itemCost = 0;
                foreach (MenuItem item in this.MenuItems)
                {
                    itemCost = Convert.ToDecimal(itemCost + item.Price);
                }
                return itemCost;
            }
        }

        [NotMapped]
        public decimal TotalAmount {
            get {
                return this.DeliveryCharge + this.ItemCost + this.TaxAmount;
            }
        }

        [Column("CustomerId", Order = 3, TypeName = "INT")]
        public int? CustomerRefId { get; set; }
        
        //Navigation Properties
        
        [ForeignKey("CustomerRefId")]
        public virtual Customer Customer { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }

        public Order()
        {
            this.MenuItems = new HashSet<MenuItem>();
        }
    }
}
