using System.ComponentModel.DataAnnotations;

namespace Rental.Domain.Models
{
    public class AddressDomainModel
    {
        [StringLength(64, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string Country { get; set; }

        [StringLength(64, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string City { get; set; }

        [StringLength(128, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string District { get; set; }

        [StringLength(128, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string Street { get; set; }

        public long AdvertId { get; set; }
        public AdvertDomainModel Advert { get; set; }
    }
}
