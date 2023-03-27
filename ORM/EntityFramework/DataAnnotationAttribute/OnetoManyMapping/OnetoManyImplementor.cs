using EntityFramework.DataAnnotationAttribute.OnetoManyMapping.OrmManager;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace EntityFramework.DataAnnotationAttribute.OnetoManyMapping
{
    public class OnetoManyImplementor
    {
        public static void Encounter()
        {
            MenuItem m1 = new MenuItem()
            {
                ItemName = "Jigiri Jinga",
                Price = 250
            };

            MenuItem m2 = new MenuItem()
            {
                ItemName = "Peruugu Vada",
                Price = 150
            };

            
            Order o1 = new Order()
            {
                TaxAmount = 12,
                DeliveryCharge = 30,
                MenuItems = new List<MenuItem>() { m1, m2 }
            };

            Customer c1 = new Customer()
            {
                FirstName = "Abhizzz",
                LastName = "Yanaz",
                Gender = Gender.Male,
                Orders = new List<Order>() { o1 }
            };

            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    //dbContext.MenuItems.Add(m1);
                    //dbContext.MenuItems.Add(m2);
                    //dbContext.Orders.Add(o1);

                    dbContext.Customers.Add(c1);
                    dbContext.SaveChanges();

                    List<Order> orders = dbContext.Orders.ToList<Order>();

                    orders.ForEach(x =>
                    {
                        Console.WriteLine($"OrderId : {x.OrderId} \nItemsCost : {x.ItemCost} \nTax : {x.TaxAmount} \nDelivery : {x.DeliveryCharge} \nTotal Pay : {x.TotalAmount}");
                    });
                }
            }
            catch(DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
