namespace Rental.Domain.Models
{
    public class FilterDomainModel
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int MinFootage { get; set; }
        public int MaxFootage { get; set; }
        public AdvertTypeDomainModel AdvertType { get; set; }
    }
}
