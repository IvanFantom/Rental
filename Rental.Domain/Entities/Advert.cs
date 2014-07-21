using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rental.Domain.Entities.Base;

namespace Rental.Domain.Entities
{
    public class Advert : Entity<long>
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public int Footage { get; set; }
        public decimal Price { get; set; }
        public bool IsReserved { get; set; }
        
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual AdvertType Type { get; set; }
        public virtual Address Address { get; set; }
    }
}
