using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain.Entities.Base
{
    public class Entity<T>:Entity
    {
        public virtual T Id { get; set; }
    }
}
