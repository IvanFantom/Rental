using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Rental.Domain;
using Rental.Domain.Models;
using Rental.Models.Entities;
using Rental.Models.Enums;
using Rental.WebUI.ViewModels.Account;
using Rental.WebUI.ViewModels.Advert;
using Rental.WebUI.ViewModels.Enums;

namespace Rental.ObjectMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            #region USER
            // DAL <-> BLL
            Mapper.CreateMap<User, UserDomainModel>();
            Mapper.CreateMap<UserDomainModel, User>();
            
            // BLL <-> WebUI
            Mapper.CreateMap<UserDomainModel, UserCabinetViewModel>();

            Mapper.CreateMap<UserDomainModel, EditUserViewModel>();
            Mapper.CreateMap<EditUserViewModel, UserDomainModel>();
            #endregion

            #region ADVERT
            // DAL <-> BLL
            Mapper.CreateMap<Advert, AdvertDomainModel>();
            Mapper.CreateMap<AdvertDomainModel, Advert>();

            // BLL <-> WebUI
            Mapper.CreateMap<AdvertDomainModel, AdvertViewModel>();
            Mapper.CreateMap<AdvertViewModel, AdvertDomainModel>();
            #endregion

            #region ADDRESS
            // DAL <-> BLL
            Mapper.CreateMap<Address, AddressDomainModel>();
            Mapper.CreateMap<AddressDomainModel, Address>();

            // BLL <-> WebUI
            Mapper.CreateMap<AddressDomainModel, AddressViewModel>();
            Mapper.CreateMap<AddressViewModel, AddressDomainModel>();
            #endregion

            #region ADVERT_TYPE
            // DAL <-> BLL
            Mapper.CreateMap<AdvertType, AdvertTypeDomainModel>();
            Mapper.CreateMap<AdvertTypeDomainModel, AdvertType>();

            // BLL <-> WebUI
            Mapper.CreateMap<AdvertTypeDomainModel, AdvertTypeViewModel>();
            Mapper.CreateMap<AdvertTypeViewModel, AdvertTypeDomainModel>();
            #endregion
        }
    }
}
