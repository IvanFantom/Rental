using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Common
{
    public interface IMembershipService
    {
        void LogInUser(long userId);
        void LogOutUser(long userId);
    }
}
