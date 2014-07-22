using System.ComponentModel.DataAnnotations;
using Rental.Models.Entities.Base;
using Rental.Models.Enums;

namespace Rental.Models.Entities
{
    public class Advert : Entity<long>
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public int Footage { get; set; }
        public decimal Price { get; set; }
        public bool IsReserved { get; set; }
        
        public long UserId { get; set; }
        public virtual User User { get; set; }
        public virtual AdvertType Type { get; set; }
        public virtual Address Address { get; set; }
    }
}
