using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rental.Models.Entities
{
    public class User : IdentityUser
    {
        private ICollection<Advert> _adverts;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Advert> Adverts 
        {
            get { return _adverts ?? (_adverts = new HashSet<Advert>()); }
            set { _adverts = value; }
        }
    }
}
