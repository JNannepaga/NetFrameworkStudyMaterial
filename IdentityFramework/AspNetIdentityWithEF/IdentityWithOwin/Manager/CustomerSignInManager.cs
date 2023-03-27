using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace AspNetIdentityOwinIntegration.Manager
{
    public class CustomerSignInManager : SignInManager<Customer, string>
    {
        public CustomerSignInManager(UserManager<Customer, string> userManager, IAuthenticationManager authenticationManager) 
            : base(userManager, authenticationManager)
        {

        }

        public static CustomerSignInManager Create(IdentityFactoryOptions<CustomerSignInManager> options, IOwinContext context)
        {
            return new CustomerSignInManager(context.GetUserManager<CustomerManager>(), context.Authentication);
        }
    }
}