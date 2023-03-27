using System;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Owin;
using IdentityOwinIntegrationWithoutEF.IdentityManagement;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

[assembly: OwinStartup(typeof(IdentityOwinIntegrationWithoutEF.App_Start.Startup))]

namespace IdentityOwinIntegrationWithoutEF.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //Initilize AuthAPI, AppUserManager & AppSignInManager for IdentityPrincipals
            app.CreatePerOwinContext<AuthAPI>(AuthAPI.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //Cookie Middleware
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = CookieAuthenticationDefaults.AuthenticationType,
                LoginPath = new PathString("/Account/Login"),
                AuthenticationMode = AuthenticationMode.Active,
                Provider = new CookieAuthenticationProvider()
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            
            //Set AuthType = Cookie as default.
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            //Use OpenID Connect
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions() { 
                AuthenticationMode = AuthenticationMode.Passive,
                AuthenticationType = ApplicationConstants.AuthenicationType_Google,
                Authority = ApplicationConstants.Authority_Google,
                Scope = ApplicationConstants.Scope_Google,
                ClientId = ApplicationConstants.ClientId_Google,
                RedirectUri = ApplicationConstants.RedirectUri_Google,
                ResponseType = "id_token",

                //validation after the token is issued
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = ApplicationConstants.Authority_Google,
                    ValidateIssuer = true,
                    ValidAudience = ApplicationConstants.ClientId_Google,
                    ValidateAudience = true
                },

                Notifications = new OpenIdConnectAuthenticationNotifications()
                {
                    SecurityTokenValidated = (ctx) =>
                    {
                        ClaimsIdentity identity = ctx.AuthenticationTicket.Identity;
                        identity.TryRemoveClaim(identity.FindFirst("azp"));
                        identity.TryRemoveClaim(identity.FindFirst("aud"));
                        identity.TryRemoveClaim(identity.FindFirst("nonce"));
                        return Task.FromResult(0);
                    }
                }
            });
            
        }
    }
}
