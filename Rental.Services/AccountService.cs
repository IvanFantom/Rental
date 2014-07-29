using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Rental.Common;
using Rental.Data;
using Rental.Domain.Models;
using Rental.Models.Entities;

namespace Rental.Services
{
    public class AccountService : IAccountService
    {
        protected UnitOfWork _unitOfWork;

        public AccountService(IAuthenticationManager authenticationManager)
        {
            _unitOfWork = new UnitOfWork();
            AuthenticationManager = authenticationManager;
        }

        public UserManager<User> UserManager { get; private set; }
        public IAuthenticationManager AuthenticationManager { get; private set; }

        private void SignInAsync(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public UserDomainModel Login(string userName, string password, bool isPersistent)
        {
            var user = UserManager.Find(userName, password);
            if (user != null)
            {
                SignInAsync(user, isPersistent);
                
                var model = Mapper.Map<UserDomainModel>(user);

                return model;
            }

            return null;
        }

        public IdentityResult Register(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public UserDomainModel GetUser(object userId)
        {
            throw new NotImplementedException();
        }

        public IdentityResult UpdateUser(object userId)
        {
            throw new NotImplementedException();
        }
    }
}