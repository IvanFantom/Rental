﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Rental.Domain;
using Rental.Domain.Models;
using Rental.IoC;
using Rental.Models.Entities;
using Rental.Models.Enums;
using Rental.WebUI.ViewModels.Account;
using Rental.WebUI.ViewModels.Advert;
using Rental.WebUI.ViewModels.Enums;
using Rental.WebUI.ViewModels.Home;

namespace Rental.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            DependencyResolver.SetResolver(new NinjectDependencyResolver());
            ConfigureModelMappings();
        }

        public static void ConfigureModelMappings()
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

            #region ADVERT_FILTER
            // BLL <-> WebUI
            Mapper.CreateMap<FilterViewModel, FilterDomainModel>();
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