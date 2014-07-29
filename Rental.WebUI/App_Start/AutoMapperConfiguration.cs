using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Rental.Domain.Models;
using Rental.Models.Entities;
using Rental.WebUI.Models.Account;

namespace Rental.WebUI.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<User, UserDomainModel>();
            Mapper.CreateMap<UserDomainModel, User>();
            
            Mapper.CreateMap<Advert, AdvertDomainModel>();
            Mapper.CreateMap<AdvertDomainModel, Advert>();

            Mapper.CreateMap<Address, AddressDomainModel>();
            Mapper.CreateMap<AddressDomainModel, Address>();
        }
    }
}