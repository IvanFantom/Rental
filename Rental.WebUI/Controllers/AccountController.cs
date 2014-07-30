using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Rental.Common;
using Rental.Domain.Models;
using Rental.WebUI.ViewModels.Account;

namespace Rental.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

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

            var user = await _accountService.LoginAsync(model.UserName, model.Password, model.RememberMe, AuthenticationManager);
            if (user != null)
            {
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

            var result = await _accountService.RegisterAsync(model.UserName, model.Password, AuthenticationManager);
            if (result.Succeeded)
            {
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
            var user = _accountService.GetUser(User.Identity.GetUserId());
            var model = Mapper.Map<UserDomainModel, UserCabinetViewModel>(user);

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

            var user = _accountService.GetUser(User.Identity.GetUserId());
            var model = Mapper.Map<UserDomainModel, EditUserViewModel>(user);

            return View(model);
        }

        //
        // POST: /Account/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile(EditUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = _accountService.GetUser(User.Identity.GetUserId());
            user = Mapper.Map<EditUserViewModel, UserDomainModel>(model, user);
            var result = await _accountService.UpdateUserAsync(User.Identity.GetUserId(), user);
            if (result.Succeeded)
            {
                return RedirectToAction("EditProfile", new { Message = ManageMessageId.EditProfileSuccess });
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
            var result = await _accountService.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return RedirectToAction("Security", new { message = ManageMessageId.ChangePasswordSuccess });
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
            _accountService.SignOut(AuthenticationManager);
            
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