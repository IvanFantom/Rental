using System.Data;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Rental.Common;
using Rental.Domain.Models;
using Rental.Interfaces;
using Rental.Models.Entities;

namespace Rental.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDomainModel> LoginAsync(string userName, string password, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new NoNullAllowedException();
            }

            var user = await _unitOfWork.UserManager.FindAsync(userName, password);

            if (user == null) return null;

            await SignInAsync(user, isPersistent, authenticationManager);
            var model = Mapper.Map<User, UserDomainModel>(user);

            return model;
        }

        public async Task<IdentityResult> RegisterAsync(string userName, string password, IAuthenticationManager authenticationManager)
        {
            var user = new User { UserName = userName };
            var result = await _unitOfWork.UserManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await SignInAsync(user, false, authenticationManager);
            }

            return result;
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var result = await _unitOfWork.UserManager.ChangePasswordAsync(userId, currentPassword, newPassword);

            return result;
        }

        public UserDomainModel GetUser(string userId)
        {
            var user = _unitOfWork.UserManager.FindById(userId);
            if (user == null)
            {
                return null;
            }

            var model = Mapper.Map<User, UserDomainModel>(user);

            return model;
        }

        public async Task<IdentityResult> UpdateUserAsync(string userId, UserDomainModel model)
        {
            var user = _unitOfWork.UserManager.FindById(userId);
            user = Mapper.Map<UserDomainModel, User>(model, user);
            var result = await _unitOfWork.UserManager.UpdateAsync(user);

            return result;
        }

        public void SignOut(IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut();
        }

        private async Task SignInAsync(User user, bool isPersistent, IAuthenticationManager authenticationManager)
        {
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await _unitOfWork.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, identity);
        }
    }
}
