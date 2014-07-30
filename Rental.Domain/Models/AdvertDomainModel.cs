using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental.Domain.Models
{
    public class AdvertDomainModel
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int Footage { get; set; }
        public decimal Price { get; set; }
        public bool IsReserved { get; set; }

        public string UserId { get; set; }
        public virtual UserDomainModel User { get; set; }
        public virtual AdvertTypeDomainModel Type { get; set; }
        public virtual AddressDomainModel Address { get; set; }
    }
}
