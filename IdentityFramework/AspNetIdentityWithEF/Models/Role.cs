
using System.Collections.Generic;

namespace AspNetIdentityOwinIntegration
{
    public partial class Role
    {
        #region Constructor
        public Role()
        {

        }

        public Role(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        #endregion

        //Properties
        public int Id { get; }
        public string Name { get; set; }

        //Navigational Properties
        public ICollection<Customer> Customers { get; set; }
        
        //Default Customers
        public static Role LoyalCustomer = new Role(1, "LoyalCustomer");
        public static Role PremierCustomer = new Role(2, "PremierCustomer");
        public static Role NewArraivalCustomer = new Role(3, "NewArraivalCustomer");

    }
}
