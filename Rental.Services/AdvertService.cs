using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Rental.Common;
using Rental.Domain;
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
            
            if (user == null)
            {
                return null;
            }

            var adverts = user.Adverts
                .Select(Mapper.Map<Advert, AdvertDomainModel>)
                .AsQueryable();

            return adverts;
        }

        public IEnumerable<AdvertDomainModel> GetAdverts(FilterDomainModel filter)
        {
            Expression<Func<Advert, bool>> expression = x =>
                                                        filter.MinPrice <= x.Price && x.Price <= filter.MaxPrice &&
                                                        filter.MinFootage <= x.Footage && x.Footage <= filter.MaxFootage &&
                                                        (filter.AdvertType == AdvertTypeDomainModel.None || ((int)x.Type == (int)filter.AdvertType));

            var adverts = _unitOfWork.GetRepository<Advert>()
                .Filter(expression)
                .ToList();
            var proxy = adverts.Select(Mapper.Map<Advert, AdvertDomainModel>);

            return proxy;
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

            if (advert == null)
            {
                return null;
            }

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
