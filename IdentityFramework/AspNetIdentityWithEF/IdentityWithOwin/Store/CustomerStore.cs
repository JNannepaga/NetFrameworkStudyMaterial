using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetIdentityOwinIntegration.Store
{
    public class CustomerStore : UserStore<Customer>
    {
        public CustomerStore(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {

        }
    }
}
