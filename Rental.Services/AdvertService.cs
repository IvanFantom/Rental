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
    public class AdvertService : IAdvertService
    {
        protected UnitOfWork _unitOfWork;

        public AdvertService()
        {
            _unitOfWork = new UnitOfWork();
        }
    }
}
