using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Provider;
using PagedList;
using Rental.Common;
using Rental.Domain.Models;
using Rental.WebUI.ViewModels.Advert;
using Rental.WebUI.ViewModels.Home;

namespace Rental.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IAdvertService _advertService;

        private int _itemsPerPage;

        public HomeController(IAdvertService advertService)
        {
            _advertService = advertService;
            _itemsPerPage = 5;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(FilterViewModel filter, int? page)
        {
            var filterModel = Mapper.Map<FilterViewModel, FilterDomainModel>(filter);
            var adverts = _advertService
                .GetAdverts(filterModel)
                .Select(Mapper.Map<AdvertDomainModel, AdvertViewModel>);
                
            var pageNumber = page ?? 1;
            var model = adverts.ToPagedList(pageNumber, _itemsPerPage);              
            
            return PartialView("_ListPartial", model);
        }

        public ActionResult Filter()
        {
            return PartialView("_FilterPartial", new FilterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterViewModel filter)
        {
            if (!ModelState.IsValid) return PartialView("_FilterPartial", filter);

            var url = Url.Action("List", "Home", routeValues: filter);
            return Json(new { success = true, url = url, replaceTarget = "#advertReplaceTarget" });
        }

        [HttpPost]
        [Authorize]
        public ActionResult Reserve(long advertId)
        {
            var userId = User.Identity.GetUserId();
            var canReserve = _advertService.CanReserve(advertId, userId);

            if (canReserve)
            {
                _advertService.ReserveAdvert(advertId, userId);
                Success("Advert was successfully reserved", true);
            }
            else
            {
                Warning("You can't reserve your own advert", true);
            }

            var url = Url.Action("List", "Home");
            return Json(new {success = true, url = url, replaceTarget = "#advertReplaceTarget"});
        }

        public ActionResult Details(long advertId)
        {
            var advert = _advertService.GetAdvert(advertId);
            var model = Mapper.Map<AdvertDomainModel, AdvertViewModel>(advert);

            return PartialView("_DetailsPartial", model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}