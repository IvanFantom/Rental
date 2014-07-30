namespace Rental.Models.Entities
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }

        public long AdvertId { get; set; }
        public virtual Advert Advert { get; set; }
    }
}
