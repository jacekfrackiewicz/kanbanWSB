using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KanbanWSB.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using KanbanWSB.Models.User;
using System.Threading.Tasks;
using Microsoft.Owin.Security;

namespace KanbanWSB.Controllers
{

    public class UserController : Controller
    {
        private AppSignInManager _signInManager;
        private AppUserManager _userManager;

        public AppSignInManager SignInManager
        {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<AppSignInManager>();
            private set => _signInManager = value;
        }

        public AppUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            private set => _userManager = value;
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
           
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogIn(LogInViewModel loginModel, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View("LogIn",loginModel);
            }


            var result = await SignInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, shouldLockout: false);

            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Main","KanbanBoard");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(loginModel);
            }
            
        }

        //Register
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    return RedirectToAction("Home", "Home");
                }
                AddErrors(result);
            }



            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Main", "KanbanBoard");
        }


        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}