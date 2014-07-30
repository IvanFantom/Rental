using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using PagedList;
using Rental.Common;
using Rental.Data;
using Rental.Domain.Models;
using Rental.Interfaces;
using Rental.Models.Entities;
using Rental.Models.Enums;
using Rental.WebUI.ViewModels.Advert;
using Rental.WebUI.ViewModels.Enums;
using Rental.WebUI.ViewModels.Home;

namespace Rental.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertService _advertService;

        private readonly IUnitOfWork _unitOfWork;
        private readonly int _itemsPerPage;

        public HomeController(IUnitOfWork unitOfWork, IAdvertService advertService)
        {
            _advertService = advertService;

            _unitOfWork = unitOfWork;
            _itemsPerPage = 5;
        }

        //
        // GET: /Home/Index
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/List
        public ActionResult List(FilterViewModel filter, int? page)
        {
            var filterModel = Mapper.Map<FilterViewModel, FilterDomainModel>(filter);
            var adverts = _advertService
                .GetAdverts(filterModel)
                .Select(Mapper.Map<AdvertDomainModel, AdvertViewModel>);
                
            var pageNumber = page ?? 1;
            var model = new ListViewModel
            {
                AdvertPagedList = adverts.ToPagedList(pageNumber, _itemsPerPage),
                CurrentFilter = filter
            };

            return PartialView("_ListPartial", model);
        }

        //
        // GET: /Home/Filter
        public ActionResult Filter()
        {
            return PartialView("_FilterPartial", new FilterViewModel());
        }

        //
        // POST: /Home/Filter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterViewModel filter)
        {
            if (!ModelState.IsValid) return PartialView("_FilterPartial", filter);

            var url = Url.Action("List", "Home", routeValues: filter);
            return Json(new { success = true, url = url });
        }

        //
        // GET: /Home/Details
        public ActionResult Details(long advertId)
        {
            var advert = _advertService.GetAdvert(advertId);
            var model = Mapper.Map<AdvertDomainModel, AdvertViewModel>(advert);

            return PartialView("_DetailsPartial", model);
        }

        //
        // GET: /Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}