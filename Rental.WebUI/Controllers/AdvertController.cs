using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Rental.Data;
using Rental.Models.Entities;
using Rental.WebUI.Models.Advert;

namespace Rental.WebUI.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        public AdvertController()
        {
            UnitOfWork = new UnitOfWork();
        }

        public UnitOfWork UnitOfWork { get; private set; }

        //
        // GET: /Advert/AdvertList
        public ActionResult AdvertList()
        {
            return View();
        }

        //
        // POST: /Advert/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvertViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = UnitOfWork.UserManager.FindById(User.Identity.GetUserId());
                var address = new Address()
                {
                    Country = model.Address.Country,
                    City = model.Address.City,
                    District = model.Address.District,
                    Street = model.Address.Street
                };
                var advert = new Advert()
                {
                    Header = model.Header,
                    Content = model.Content,
                    Footage = model.Footage,
                    Price = model.Price,
                    Type = model.AdvertType,
                    User = user,
                    Address = address
                };
                UnitOfWork.GetRepository<Advert>().Create(advert);
                UnitOfWork.Commit();

                return RedirectToAction("AdvertList");
            }

            return View("AdvertList");
        }
	}
}