using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Rental.Common;
using Rental.Domain.Models;
using Rental.WebUI.ViewModels.Advert;

namespace Rental.WebUI.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        private readonly IAdvertService _advertService;

        public AdvertController(IAdvertService advertService)
        {
            _advertService = advertService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;

            var query = _advertService.GetAdvertsByUserId(userId);
            var model = query.Select(Mapper.Map<AdvertDomainModel, AdvertViewModel>);

            return PartialView("_ListPartial", model);
        }

        public ActionResult ReservedList()
        {
            var userId = User.Identity.GetUserId();
            ViewBag.UserId = userId;

            var query = _advertService.GetReservedAdvertsByUserId(userId);
            var model = query.Select(Mapper.Map<AdvertDomainModel, AdvertViewModel>);

            return PartialView("_ReservedListPartial", model);
        }

        public ActionResult Create(string userId)
        {
            var advert = new AdvertViewModel {UserId = userId};

            return PartialView("_CreatePartial", advert);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvertViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("_CreatePartial", model);

            var advert = Mapper.Map<AdvertViewModel, AdvertDomainModel>(model);
            _advertService.CreateAdvert(model.UserId, advert);

            var url = Url.Action("List", "Advert");
            return Json(new { success = true, url = url, replaceTarget = "#advertReplaceTarget" });
        }

        public ActionResult Edit(long? advertId)
        {
            var advert = _advertService.GetAdvert(advertId);
            var model = Mapper.Map<AdvertDomainModel, AdvertViewModel>(advert);

            return PartialView("_EditPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdvertViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("_EditPartial", model);

            var advert = Mapper.Map<AdvertViewModel, AdvertDomainModel>(model);
            _advertService.UpdateAdvert(advert);

            var url = Url.Action("List", "Advert");
            return Json(new { success = true, url = url, replaceTarget = "#advertReplaceTarget" });
        }

        public ActionResult Delete(long? advertId)
        {
            var advert = _advertService.GetAdvert(advertId);
            var model = Mapper.Map<AdvertDomainModel, AdvertViewModel>(advert);

            return PartialView("_DeletePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long advertId)
        {
            _advertService.DeleteAdvert(advertId);

            var url = Url.Action("List", "Advert");
            return Json(new { success = true, url = url, replaceTarget = "#advertReplaceTarget" });
        }

        public ActionResult Details(long? advertId)
        {
            var advert = _advertService.GetAdvert(advertId);
            var model = Mapper.Map<AdvertDomainModel, AdvertViewModel>(advert);

            return PartialView("_DetailsPartial", model);
        }

        public ActionResult Unreserve(long? advertId)
        {
            var advert = _advertService.GetAdvert(advertId);
            var model = Mapper.Map<AdvertDomainModel, AdvertViewModel>(advert);

            return PartialView("_UnreservePartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unreserve(long advertId)
        {
            _advertService.UnreserveAdvert(advertId);
            
            var url = Url.Action("ReservedList", "Advert");
            return Json(new { success = true, url = url, replaceTarget = "#reservedAdvertsReplaceTarget" });
        }
	}
}