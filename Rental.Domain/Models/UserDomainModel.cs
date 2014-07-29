using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain.Models
{
    public class UserDomainModel
    {
        private ICollection<AdvertDomainModel> _adverts;

        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<AdvertDomainModel> Adverts
        {
            get { return _adverts ?? (_adverts = new HashSet<AdvertDomainModel>()); }
            set { _adverts = value; }
        }
    }
}
