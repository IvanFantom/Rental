using System.Collections.Generic;
using Rental.Models.Entities.Base;

namespace Rental.Models.Entities
{
    public class Role : Entity<long>
    {
        private ICollection<User> _users; 

        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return _users ?? (_users = new HashSet<User>()); }
            set { _users = value; }
        }
    }
}
