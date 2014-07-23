using System.Collections.Generic;

namespace Rental.Models.Entities
{
    public class Role
    {
        private ICollection<User> _users; 

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return _users ?? (_users = new HashSet<User>()); }
            set { _users = value; }
        }
    }
}
