using AspNetIdentityOwinIntegration.Store;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Threading.Tasks;

namespace AspNetIdentityOwinIntegration.Manager
{
    public class CustomerManager : UserManager<Customer>
    {
        public CustomerManager(IUserStore<Customer> store) 
            : base(store)
        {

        }

        public static CustomerManager Create(IdentityFactoryOptions<CustomerManager> options, IOwinContext context)
        {
            //Store
            CustomerStore store = new CustomerStore(context.Get<ApplicationDbContext>());
            CustomerManager manager = new CustomerManager(store);
            return manager;
        }

    }
}
