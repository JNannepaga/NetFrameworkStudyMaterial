using IdentityOwinIntegrationWithoutEF.IdentityManagement;
using IdentityOwinIntegrationWithoutEF.ViewModel;
using System.Web.Mvc;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.Owin.Security;

namespace IdentityOwinIntegrationWithoutEF.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _sigInManager;

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

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(model);

            SignInStatus signInStatusResult = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            switch (signInStatusResult)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            //Loading user's verified factors & by Default pick 1st factor and send vefificationcode Meanwhile show case the factor to user seeking for code.
            if (await SignInManager.HasBeenVerifiedAsync())
            {
                int userId = SignInManager.GetVerifiedUserId<User, int>();
                IList<string> userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
                bool isSmsTriggered = await SignInManager.SendTwoFactorCodeAsync(userFactors.FirstOrDefault());
                VerifyPhoneNumberViewModel model = new VerifyPhoneNumberViewModel()
                {
                    Number = userFactors.FirstOrDefault()
                };
                return View(model);
            }

            return View();
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(VerifyPhoneNumberViewModel model)
        {
            var result = await SignInManager.TwoFactorSignInAsync(model.Number, model.Code, isPersistent: false, rememberBrowser: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Phone = model.Phone,
                    FirstName = model.Firstname,
                    LastName = model.Lastname,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailVerified = true,
                    PhoneVerified = true,
                    TwoFactorAuthEnabled = true
                };

                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, false, false);
                    return RedirectToLocal(string.Empty);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ChallangeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { returnUrl = returnUrl })); ;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            ExternalLoginInfo loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            
            if (loginInfo == null)
                return RedirectToAction("Login", "Account");

            SignInStatus signInStatusResult = 
                await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);

            switch (signInStatusResult)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    //If there is no account then create one.
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel() { Email = loginInfo.Email });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            //If we have account in the local DB then sign-in else create one and sign-in

            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index","Home");

            if (ModelState.IsValid)
            {
                ExternalLoginInfo loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
                if(loginInfo == null)
                {
                    return View("ExternalLoginFailure");
                }
                else
                {
                    User user = new User()
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };
                    IdentityResult result = await UserManager.CreateAsync(user);

                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, false, false);
                        return RedirectToLocal(returnUrl);
                    }
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}