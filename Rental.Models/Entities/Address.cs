using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rental.Models.Entities.Base;

namespace Rental.Models.Entities
{
    public class Address : Entity<long>
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }

        [Key, ForeignKey("Advert")]
        public long AdvertId { get; set; }
        public virtual Advert Advert { get; set; }
    }
}
