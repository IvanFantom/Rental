using System.Collections.Generic;
using System.Linq;
using Rental.Domain.Models;

namespace Rental.Common
{
    public interface IAdvertService
    {
        AdvertDomainModel GetAdvert(object userId);
        
        IQueryable<AdvertDomainModel> GetAdvertsByUserId(string userId);

        IEnumerable<AdvertDomainModel> GetAdverts(FilterDomainModel filter);
        
        void CreateAdvert(string userId, AdvertDomainModel model);
        
        void UpdateAdvert(AdvertDomainModel model);
        
        void DeleteAdvert(object advertId);
    }
}
