namespace Rental.Domain.Models
{
    public class AddressDomainModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }

        public long AdvertId { get; set; }
        public AdvertDomainModel Advert { get; set; }
    }
}
