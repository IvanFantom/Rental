using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult List()
        {
            return View();
        }
        
        //
        // GET: /Advert/Index
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;

            var user = UnitOfWork.UserManager.FindById(userId);
            var model = user.Adverts.Select(x => new AdvertViewModel()
            {
                Id = x.Id,
                Header = x.Header,
                Content = x.Content,
                Footage = x.Footage,
                Price = x.Price,
                AdvertType = x.Type,
                Address = new AddressViewModel()
                {
                    Country = x.Address.Country,
                    City = x.Address.City,
                    District = x.Address.District,
                    Street = x.Address.Street
                }
            });

            return PartialView("_IndexPartial", model);
        }

        //
        // GET: /Advert/Create
        public ActionResult Create(string userId)
        {
            var advert = new AdvertViewModel() {UserId = userId};

            return PartialView("_CreatePartial", advert);
        }

        //
        // POST: /Advert/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind] AdvertViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("_CreatePartial", model);

            var user = UnitOfWork.UserManager.FindById(model.UserId);
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

            var url = Url.Action("Index", "Advert");
            return Json(new {success = true, url = url});
        }

        //
        // GET: /Advert/Edit
        [ValidateAntiForgeryToken]
        public ActionResult Edit()
        {
            return View();
        }

        //
        // GET: /Advert/Delete
        [ValidateAntiForgeryToken]
        public ActionResult Delete()
        {
            return View();
        }
	}
}