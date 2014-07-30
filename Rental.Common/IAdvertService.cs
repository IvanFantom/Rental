using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Domain.Models;

namespace Rental.Common
{
    public interface IAdvertService
    {
        IQueryable<AdvertDomainModel> GetAdvertsByUserId(string userId);
        
        void CreateAdvert(string userId, AdvertDomainModel model);
        
        AdvertDomainModel GetAdvert(object userId);
        
        void UpdateAdvert(AdvertDomainModel model);
        
        void DeleteAdvert(object advertId);
    }
}
