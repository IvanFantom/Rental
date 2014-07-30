using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Rental.Common;
using Rental.Data;
using Rental.Domain.Models;
using Rental.Interfaces;
using Rental.Models.Entities;
using Rental.Models.Enums;
using Rental.WebUI.ViewModels.Advert;
using Rental.WebUI.ViewModels.Enums;

namespace Rental.WebUI.Controllers
{
    [Authorize]
    public class AdvertController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdvertService _advertService;

        public AdvertController(IUnitOfWork unitOfWork, IAdvertService advertService)
        {
            _unitOfWork = unitOfWork;
            _advertService = advertService;
        }

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

            var query = _advertService.GetAdvertsByUserId(userId);
            var model = query.Select(Mapper.Map<AdvertDomainModel, AdvertViewModel>);

            //var user = _unitOfWork.UserManager.FindById(userId);
            //var model = user.Adverts.Select(x => new AdvertViewModel
            //{
            //    Id = x.Id,
            //    Header = x.Header,
            //    Content = x.Content,
            //    Footage = x.Footage,
            //    Price = x.Price,
            //    AdvertType = x.Type,
            //    Address = new AddressViewModel
            //    {
            //        Country = x.Address.Country,
            //        City = x.Address.City,
            //        District = x.Address.District,
            //        Street = x.Address.Street
            //    }
            //});

            return PartialView("_ListPartial", model);
        }

        //
        // GET: /Advert/Create
        public ActionResult Create(string userId)
        {
            var advert = new AdvertViewModel {UserId = userId};

            return PartialView("_CreatePartial", advert);
        }

        //
        // POST: /Advert/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AdvertViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("_CreatePartial", model);

            var advert = Mapper.Map<AdvertViewModel, AdvertDomainModel>(model);
            _advertService.CreateAdvert(model.UserId, advert);

            //var user = _unitOfWork.UserManager.FindById(model.UserId);
            //var address = new Address
            //{
            //    Country = model.Address.Country,
            //    City = model.Address.City,
            //    District = model.Address.District,
            //    Street = model.Address.Street
            //};
            //var advert = new Advert
            //{
            //    Header = model.Header,
            //    Content = model.Content,
            //    Footage = model.Footage,
            //    Price = model.Price,
            //    Type = model.AdvertType,
            //    User = user,
            //    Address = address
            //};
            //_unitOfWork.GetRepository<Advert>().Create(advert);
            //_unitOfWork.Commit();

            var url = Url.Action("List", "Advert");
            return Json(new {success = true, url = url});
        }

        //
        // GET: /Advert/Edit
        public ActionResult Edit(long? advertId)
        {
            var advert = _unitOfWork.GetRepository<Advert>().GetById(advertId);
            var model = new AdvertViewModel
            {
                Id = advert.Id,
                Header = advert.Header,
                Content = advert.Content,
                Footage = advert.Footage,
                Price = advert.Price,
                Type = (AdvertTypeViewModel) advert.Type,
                UserId = advert.UserId,
                Address = new AddressViewModel
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

            var address = new Address
            {
                AdvertId = model.Id,
                Country = model.Address.Country,
                City = model.Address.City,
                District = model.Address.District,
                Street = model.Address.Street
            };
            var advert = new Advert
            {
                Id = model.Id,
                Header = model.Header,
                Content = model.Content,
                Footage = model.Footage,
                Price = model.Price,
                Type = (AdvertType) model.Type,
                UserId = model.UserId,
            };
            _unitOfWork.GetRepository<Advert>().Update(advert);
            _unitOfWork.GetRepository<Address>().Update(address);
            _unitOfWork.Commit();

            var url = Url.Action("List", "Advert");
            return Json(new { success = true, url = url });
        }

        //
        // GET: /Advert/Delete
        public ActionResult Delete(long? advertId)
        {
            var advert = _unitOfWork.GetRepository<Advert>().GetById(advertId);
            var model = new AdvertViewModel
            {
                Id = advert.Id,
                Header = advert.Header,
                Content = advert.Content,
                Footage = advert.Footage,
                Price = advert.Price,
                Type = (AdvertTypeViewModel)advert.Type,
                Address = new AddressViewModel
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
            _unitOfWork.GetRepository<Advert>().Delete(advertId);
            _unitOfWork.Commit();

            var url = Url.Action("List", "Advert");
            return Json(new { success = true, url = url });
        }
	}
}