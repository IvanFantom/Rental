using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain.Entities
{
    public class Advert
    {
        public long Id { get; set; }
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
