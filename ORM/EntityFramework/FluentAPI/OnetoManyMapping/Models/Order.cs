using System;
using System.Collections.Generic;

namespace EntityFramework.FluentAPI.OnetoManyMapping
{
    public class Order
    {
        //Scalar Properties
        public int OrderId { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DeliveryCharge { get; set; }
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
        public decimal TotalAmount {
            get {
                return this.DeliveryCharge + this.ItemCost + this.TaxAmount;
            }
        }

        public int CustomerRefId { get; set; }
        
        //Navigation Properties
        public virtual Customer Customer { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }

        public Order()
        {
            this.MenuItems = new HashSet<MenuItem>();
        }
    }
}
