using AspNetIdentityOwinIntegration.Manager;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(AspNetIdentityOwinIntegration.Startup))]

namespace AspNetIdentityOwinIntegration
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //Create an appDBContext
            app.CreatePerOwinContext<ApplicationDbContext>(ApplicationDbContext.Create);

            app.CreatePerOwinContext<CustomerManager>(CustomerManager.Create);

            app.CreatePerOwinContext<CustomerSignInManager>(CustomerSignInManager.Create);

            //Authentication
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

        }
    }
}
