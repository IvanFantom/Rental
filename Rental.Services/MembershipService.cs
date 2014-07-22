using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Common;
using Rental.Interfaces;

namespace Rental.Services
{
    public class MembershipService : BaseService, IMembershipService
    {
        public MembershipService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public void LogInUser(long userId)
        {
            throw new NotImplementedException();
        }

        public void LogOutUser(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
