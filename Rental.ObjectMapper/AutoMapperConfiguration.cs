using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Rental.Domain.Models;
using Rental.Models.Entities;

namespace Rental.ObjectMapper
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<User, UserDomainModel>();
            Mapper.CreateMap<UserDomainModel, User>();
        }
    }
}
