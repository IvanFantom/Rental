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
        IAuthenticationManager AuthenticationManager { get; }

        UserDomainModel Login(string userName, string password, bool isPersistent);
        IdentityResult Register(string userName, string password);
        UserDomainModel GetUser(object userId);
        IdentityResult UpdateUser(object userId);
    }
}
