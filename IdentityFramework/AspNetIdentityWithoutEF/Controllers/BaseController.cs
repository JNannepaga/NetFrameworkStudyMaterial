using IdentityOwinIntegrationWithoutEF.IdentityManagement;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Mvc;

namespace IdentityOwinIntegrationWithoutEF.Controllers
{
    public class BaseController : Controller
    {
        protected AppUserInfo GetCurrentUser()
        {
            if (System.Web.HttpContext.Current.User != null
                && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                IPrincipal user = System.Web.HttpContext.Current.User;
                ClaimsIdentity claimsIdentity = (ClaimsIdentity)user.Identity;
                int id = Convert.ToInt32(claimsIdentity.FindFirst(CustomClaims.Id)?.Value);
                string userName = claimsIdentity.FindFirst(CustomClaims.UserName)?.Value;
                string name = claimsIdentity.FindFirst(CustomClaims.Name)?.Value;
                string email = claimsIdentity.FindFirst(CustomClaims.Email)?.Value;
                string phone = claimsIdentity.FindFirst(CustomClaims.Phone)?.Value;

                return new AppUserInfo(id, userName, name, email, phone);
            }
            else
            {
                return AppUserInfo.SystemLogger;
            }
        }
    }
}