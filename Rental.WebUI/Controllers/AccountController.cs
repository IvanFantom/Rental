using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rental.Data;
using Rental.Interfaces;

namespace Rental.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
            UnitOfWork = new UnitOfWork();
        }

        public IUnitOfWork UnitOfWork { get; private set; }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            return RedirectToAction("Index", "Home");
        }
	}
}