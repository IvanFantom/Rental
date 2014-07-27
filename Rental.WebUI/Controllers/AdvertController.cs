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
        // GET: /Advert/List
        public ActionResult Index()
        {
            return View();
        }
        
        //
        // GET: /Advert/Index
        public ActionResult List()
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

            return PartialView("_ListPartial", model);
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
        public ActionResult Create(AdvertViewModel model)
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

            var url = Url.Action("List", "Advert");
            return Json(new {success = true, url = url});
        }

        //
        // GET: /Advert/Edit
        public ActionResult Edit(long? advertId)
        {
            var advert = UnitOfWork.GetRepository<Advert>().GetById(advertId);
            var model = new AdvertViewModel()
            {
                Id = advert.Id,
                Header = advert.Header,
                Content = advert.Content,
                Footage = advert.Footage,
                Price = advert.Price,
                AdvertType = advert.Type,
                UserId = advert.UserId,
                Address = new AddressViewModel()
                {
                    Country = advert.Address.Country,
                    City = advert.Address.City,
                    District = advert.Address.District,
                    Street = advert.Address.Street
                }
            };

            return PartialView("_EditPartial", model);
        }

        //
        // POST: /Advert/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdvertViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("_EditPartial", model);

            var address = new Address()
            {
                AdvertId = model.Id,
                Country = model.Address.Country,
                City = model.Address.City,
                District = model.Address.District,
                Street = model.Address.Street
            };
            var advert = new Advert()
            {
                Id = model.Id,
                Header = model.Header,
                Content = model.Content,
                Footage = model.Footage,
                Price = model.Price,
                Type = model.AdvertType,
                UserId = model.UserId,
            };
            UnitOfWork.GetRepository<Advert>().Update(advert);
            UnitOfWork.GetRepository<Address>().Update(address);
            UnitOfWork.Commit();

            var url = Url.Action("List", "Advert");
            return Json(new { success = true, url = url });
        }

        //
        // GET: /Advert/Delete
        public ActionResult Delete(long? advertId)
        {
            var advert = UnitOfWork.GetRepository<Advert>().GetById(advertId);
            var model = new AdvertViewModel()
            {
                Id = advert.Id,
                Header = advert.Header,
                Content = advert.Content,
                Footage = advert.Footage,
                Price = advert.Price,
                AdvertType = advert.Type,
                Address = new AddressViewModel()
                {
                    Country = advert.Address.Country,
                    City = advert.Address.City,
                    District = advert.Address.District,
                    Street = advert.Address.Street
                }
            };

            return PartialView("_DeletePartial", model);
        }

        //
        // POST: /Advert/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long advertId)
        {
            UnitOfWork.GetRepository<Advert>().Delete(advertId);
            UnitOfWork.Commit();

            var url = Url.Action("List", "Advert");
            return Json(new { success = true, url = url });
        }
	}
}