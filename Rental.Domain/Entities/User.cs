using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Domain.Entities.Base;

namespace Rental.Domain.Entities
{
    public class User : Entity<long>
    {
        private ICollection<Advert> _adverts;
        private ICollection<Role> _roles;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Advert> Adverts 
        {
            get { return _adverts ?? (_adverts = new HashSet<Advert>()); }
            set { _adverts = value; }
        }
        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new HashSet<Role>()); }
            set { _roles = value; }
        }
    }
}
