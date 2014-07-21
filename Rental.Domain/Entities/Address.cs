using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Domain.Entities.Base;

namespace Rental.Domain.Entities
{
    public class Address : Entity<long>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }

        public virtual Advert Advert { get; set; }
        public long AdvertId { get; set; }
    }
}
