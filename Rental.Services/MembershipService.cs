using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Common;
using Rental.Data;
using Rental.Interfaces;

namespace Rental.Services
{
    public class MembershipService : IMembershipService
    {
        protected UnitOfWork _unitOfWork;

        public MembershipService()
        {
            _unitOfWork = new UnitOfWork();
        }

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
