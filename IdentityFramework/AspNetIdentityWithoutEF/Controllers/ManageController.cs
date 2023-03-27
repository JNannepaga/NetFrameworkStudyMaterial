using IdentityOwinIntegrationWithoutEF.IdentityManagement;
using IdentityOwinIntegrationWithoutEF.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IdentityOwinIntegrationWithoutEF.Controllers
{
    [Authorize]
    public class ManageController : BaseController
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _sigInManager;
        private AppUserInfo _appUserInfo;
        
        public ManageController()
        {
            _appUserInfo = base.GetCurrentUser();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _sigInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _sigInManager = value;
            }
        }

        [HttpGet]
        public async Task<ActionResult> VerifyPhoneNumber()
        {
            VerifyPhoneNumberViewModel model = new VerifyPhoneNumberViewModel()
            {
                Number = _appUserInfo.Phone
            };

            // Generate the token and send it
            string code = await UserManager.GenerateChangePhoneNumberTokenAsync(Convert.ToInt32(User.Identity.GetUserId()), model.Number);
            if (UserManager.SmsService != null)
            {
                IdentityMessage message = new IdentityMessage
                {
                    Subject = "EMSToolware verification",
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isVerified = await UserManager.VerifyChangePhoneNumberTokenAsync(Convert.ToInt32(User.Identity.GetUserId()),model.Code, _appUserInfo.Phone);
            return RedirectToAction("Index", "Home");
        }
    }
}