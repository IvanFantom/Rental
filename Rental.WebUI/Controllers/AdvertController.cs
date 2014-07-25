using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rental.Data;
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
        public ActionResult Create(AdvertViewModel model)
        {
            return View();
        }
	}
}