using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class ChallangeResult : HttpUnauthorizedResult
    {
        private const string XsrfKey = "XsrfId";
        
        public ChallangeResult(string loginProvider, string redirectURI)
            : this(loginProvider, redirectURI, 0)
        {

        }

        public ChallangeResult(string loginProvider, string redirectURI, int userId)
        {
            this.LoginProvider = loginProvider;
            this.RedirectURI = redirectURI;
            this.UserId = userId;
        }

        public int UserId { get; set; }

        public string RedirectURI { get; set; }

        public string LoginProvider { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            AuthenticationProperties authProps = new AuthenticationProperties()
            {
                RedirectUri = this.RedirectURI
            };

            if (UserId != 0)
                authProps.Dictionary[XsrfKey] = UserId.ToString();

            context.HttpContext.GetOwinContext().Authentication.Challenge(authProps, LoginProvider);    
        }
    }
}