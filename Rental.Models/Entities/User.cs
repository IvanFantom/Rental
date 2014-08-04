using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rental.Models.Entities
{
    public class User : IdentityUser
    {
        private ICollection<Advert> _adverts;
        private ICollection<Advert> _reservedAdverts;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Advert> Adverts 
        {
            get { return _adverts ?? (_adverts = new HashSet<Advert>()); }
            set { _adverts = value; }
        }
        public virtual ICollection<Advert> ReservedAdverts
        {
            get { return _reservedAdverts ?? (_reservedAdverts = new HashSet<Advert>()); }
            set { _reservedAdverts = value; }
        } 
    }
}
