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

        public AdvertDomainModel GetAdvert(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdvert(AdvertDomainModel model)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdvert(long advertId)
        {
            throw new NotImplementedException();
        }
    }
}
