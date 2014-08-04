using System.Collections.Generic;
using System.Linq;
using Rental.Domain.Models;

namespace Rental.Common
{
    public interface IAdvertService
    {
        bool CanReserve(object advertId, string userId);
        
        void CreateAdvert(string userId, AdvertDomainModel model);
        
        void DeleteAdvert(object advertId);
        
        AdvertDomainModel GetAdvert(object advertId);
        
        IEnumerable<AdvertDomainModel> GetAdverts(FilterDomainModel filter);
        
        IQueryable<AdvertDomainModel> GetAdvertsByUserId(string userId);

        IQueryable<AdvertDomainModel> GetReservedAdvertsByUserId(string userId);

        bool ReserveAdvert(object advertId, string userId);
        
        bool UnreserveAdvert(object advertId);
        
        void UpdateAdvert(AdvertDomainModel model);
    }
}
