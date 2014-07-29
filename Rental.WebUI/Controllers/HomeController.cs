﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using Rental.Data;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly int _itemsPerPage;

        public HomeController(IUnitOfWork unitOfWork)
        {
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
            Expression<Func<Advert, bool>> expression = x =>
                                                        filter.MinPrice <= x.Price && x.Price <= filter.MaxPrice &&
                                                        filter.MinFootage <= x.Footage && x.Footage <= filter.MaxFootage &&
                                                        (filter.AdvertType == AdvertTypeViewModel.None || ((int)x.Type == (int)filter.AdvertType));

            var list = _unitOfWork
                .GetRepository<Advert>()
                .Filter(expression)
                .Select(x => new AdvertViewModel
                {
                Id = x.Id,
                Header = x.Header,
                Content = x.Content,
                Footage = x.Footage,
                Price = x.Price,
                AdvertType = x.Type,
                Address = new AddressViewModel
                {
                    Country = x.Address.Country,
                    City = x.Address.City,
                    District = x.Address.District,
                    Street = x.Address.Street
                }
            }).ToList();

            var pageNumber = page ?? 1;
            var model = new ListViewModel
            {
                AdvertPagedList = list.ToPagedList(pageNumber, _itemsPerPage),
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
            var advert = _unitOfWork.GetRepository<Advert>().GetById(advertId);
            var model = new AdvertViewModel
            {
                Header = advert.Header,
                Content = advert.Content,
                Footage = advert.Footage,
                Price = advert.Price,
                AdvertType = advert.Type,
                Address = new AddressViewModel
                {
                    Country = advert.Address.Country,
                    City = advert.Address.City,
                    District = advert.Address.District,
                    Street = advert.Address.Street
                }
            };

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