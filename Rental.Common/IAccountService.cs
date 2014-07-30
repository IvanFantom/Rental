using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Rental.Domain.Models;

namespace Rental.Common
{
    public interface IAccountService
    {
        Task<UserDomainModel> LoginAsync(string userName, string password, bool isPersistent, IAuthenticationManager authenticationManager);
        
        Task<IdentityResult> RegisterAsync(string userName, string password, IAuthenticationManager authenticationManager);
        
        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        
        UserDomainModel GetUser(string userId);
        
        Task<IdentityResult> UpdateUserAsync(string userId, UserDomainModel model);

        void SignOut(IAuthenticationManager authenticationManager);
    }
}
