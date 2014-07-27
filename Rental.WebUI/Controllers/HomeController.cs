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
    public class HomeController : Controller
    {
        public HomeController()
        {
            UnitOfWork = new UnitOfWork();
        }

        public UnitOfWork UnitOfWork { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var model = UnitOfWork
                .GetRepository<Advert>()
                .All()
                .Select(x => new AdvertViewModel()
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
            }).AsEnumerable();

            return PartialView("_ListPartial", model);
        }

        public ActionResult Details(long advertId)
        {
            var advert = UnitOfWork.GetRepository<Advert>().GetById(advertId);
            var model = new AdvertViewModel()
            {
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

            return PartialView("_DetailsPartial", model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
	}
}