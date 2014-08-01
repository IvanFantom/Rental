using System.ComponentModel.DataAnnotations;

namespace Rental.Domain.Models
{
    public class AdvertDomainModel
    {
        public long Id { get; set; }

        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Header { get; set; }

        public string Content { get; set; }

        [Range(typeof(decimal), "0", "20000", ErrorMessage = "{0} is out of range")]
        public decimal Price { get; set; }

        [Range(0, 20000, ErrorMessage = "{0} is out of range")]
        public int Footage { get; set; }

        public bool IsReserved { get; set; }

        public string UserId { get; set; }
        public UserDomainModel User { get; set; }
        public AdvertTypeDomainModel Type { get; set; }
        public AddressDomainModel Address { get; set; }
    }
}
