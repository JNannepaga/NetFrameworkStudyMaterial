using IdentityOwinIntegrationWithoutEF.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class ApplicationSignInManager : SignInManager<User, int>
    {
        public ApplicationSignInManager(UserManager<User, int> userManager, IAuthenticationManager authenticationManager) 
            : base(userManager, authenticationManager)
        {

        }

        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            ClaimsIdentity userIdentity = await ((ApplicationUserManager)UserManager).CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim(CustomClaims.Id, user.Id.ToString(), ClaimValueTypes.Integer32));
            userIdentity.AddClaim(new Claim(CustomClaims.UserName, user.UserName, ClaimValueTypes.String));
            userIdentity.AddClaim(new Claim(CustomClaims.Name, user.FullName, ClaimValueTypes.String));
            
            if(user.Phone != null)
                userIdentity.AddClaim(new Claim(CustomClaims.Phone, user.Phone, ClaimValueTypes.String));

            if (user.Email != null)
                userIdentity.AddClaim(new Claim(CustomClaims.Email, user.Email, ClaimValueTypes.String));

            foreach (MyRole role in user.Roles)
            {
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, role.Name, ClaimValueTypes.String));
            }

            return userIdentity;
        }
        
        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            ApplicationSignInManager manager = new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            return manager;
        }
    }
}