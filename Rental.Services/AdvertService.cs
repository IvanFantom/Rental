using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Rental.Common;
using Rental.Data;
using Rental.Domain.Models;
using Rental.Interfaces;
using Rental.Models.Entities;

namespace Rental.Services
{
    public class AdvertService : IAdvertService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdvertService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IQueryable<AdvertDomainModel> GetAdvertsByUserId(string userId)
        {
            var user = _unitOfWork.UserManager.FindById(userId);
            var adverts = user.Adverts.Select(Mapper.Map<Advert, AdvertDomainModel>).AsQueryable();

            return adverts;
        }

        public void CreateAdvert(string userId, AdvertDomainModel model)
        {
            var user = _unitOfWork.UserManager.FindById(userId);
            var advert = Mapper.Map<AdvertDomainModel, Advert>(model);
            advert.User = user;

            _unitOfWork.GetRepository<Advert>().Create(advert);
            _unitOfWork.Commit();
        }

        public AdvertDomainModel GetAdvert(object userId)
        {
            var advert = _unitOfWork.GetRepository<Advert>().GetById(userId);
            var model = Mapper.Map<Advert, AdvertDomainModel>(advert);

            return model;
        }

        public void UpdateAdvert(AdvertDomainModel model)
        {
            var advert = Mapper.Map<AdvertDomainModel, Advert>(model);
            advert.Address.AdvertId = advert.Id;
            _unitOfWork.GetRepository<Advert>().Update(advert);
            _unitOfWork.GetRepository<Address>().Update(advert.Address);

            _unitOfWork.Commit();
        }

        public void DeleteAdvert(object advertId)
        {
            _unitOfWork.GetRepository<Advert>().Delete(advertId);
            _unitOfWork.Commit();
        }
    }
}
