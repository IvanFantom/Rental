using Rental.Models.Enums;

namespace Rental.Models.Entities
{
    public class Advert
    {
        public long Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public int Footage { get; set; }
        public decimal Price { get; set; }
        public bool IsReserved { get; set; }
        
        public string UserId { get; set; }
        public virtual User User { get; set; }
        
        public string ReservatorId { get; set; }
        public virtual User Reservator { get; set; }

        public virtual AdvertType Type { get; set; }
        public virtual Address Address { get; set; }
    }
}
