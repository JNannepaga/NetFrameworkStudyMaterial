using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class ApplicationUserManager : UserManager<User, int>
    {
        public ApplicationUserManager(IUserStore<User, int> store) 
            : base(store)
        {

        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            UserStore store = new UserStore(context.Get<AuthAPI>());
            ApplicationUserManager manager = new ApplicationUserManager(store);

            //Password Haser
            manager.PasswordHasher = new SimplePasswordHasher();
            
            //Configure UserNames
            manager.UserValidator = new UserValidator<User, int>(manager)
            {
                RequireUniqueEmail = true
            };

            //Configure Password
            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 5,
            };
            //Configure SMS app
            manager.SmsService = new TwilioSmsService();

            //Configure TwoFactorAuthentication
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<User, int>
            {
                MessageFormat = "EmsToolware:- Your security code is: {0}"
            });
            IDataProtectionProvider dataProtectorTokenProvider = options.DataProtectionProvider;
            
            if (dataProtectorTokenProvider != null)
                manager.UserTokenProvider = new DataProtectorTokenProvider<User, int>
                    (dataProtectorTokenProvider.Create("ASP.NET Identity"));

            return manager;
        }
    }
}