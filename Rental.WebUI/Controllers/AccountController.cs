using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Rental.Data;
using Rental.Interfaces;
using Rental.Models.Entities;
using Rental.WebUI.ViewModels.Account;

namespace Rental.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            UserManager = _unitOfWork.UserManager;
        }

        public UserManager<User> UserManager { get; private set; }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await UserManager.FindAsync(model.UserName, model.Password);
            if (user != null)
            {
                await SignInAsync(user, model.RememberMe);
                return RedirectToLocal(returnUrl);
            }
            
            ModelState.AddModelError("", "Invalid username or password.");
            
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new User { UserName = model.UserName };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            AddErrors(result);
            
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/Summary
        public ActionResult Summary()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            var model = new UserCabinetViewModel
            {
                UserName = user.UserName
            };

            return View(model);
        }

        //
        // GET: /Account/EditProfile
        public ActionResult EditProfile(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.EditProfileSuccess? "You profile data has been updated"
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";

            var user = UserManager.FindById(User.Identity.GetUserId());
            var model = new EditUserViewModel
            {
                LastName = user.LastName,
                Email = user.Email
            };

            return View(model);
        }

        //
        // POST: /Account/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile(EditUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = UserManager.FindById(User.Identity.GetUserId());
            user.LastName = model.LastName;
            user.Email = model.Email;

            var result = await UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("EditProfile", new {Message = ManageMessageId.EditProfileSuccess});
            }
                
            AddErrors(result);

            return View(model);
        }

        //
        // GET: /Account/Security
        public ActionResult Security(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";

            return View();
        }

        //
        // POST: /Account/Sequrity
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Security(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var userId = User.Identity.GetUserId();
            var result = await UserManager.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("Security", new {message = ManageMessageId.ChangePasswordSuccess});
            }

            AddErrors(result);

            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        public enum ManageMessageId
        {
            EditProfileSuccess,
            ChangePasswordSuccess,
            Error
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
        private async Task SignInAsync(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        #endregion
    }
}