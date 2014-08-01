using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace Rental.Domain.Models
{
    public class FilterDomainModel
    {
        [Range(typeof(decimal), "0", "20000", ErrorMessage = "{0} is out of range")]
        public decimal MinPrice { get; set; }

        [Range(typeof(decimal), "0", "20000", ErrorMessage = "{0} is out of range")]
        [GreaterThanOrEqualTo("MinPrice", ErrorMessage = "MinPrice should be <= MaxPrice")]
        public decimal MaxPrice { get; set; }

        [Range(0, 20000, ErrorMessage = "{0} is out of range")]
        public int MinFootage { get; set; }

        [Range(0, 20000, ErrorMessage = "{0} is out of range")]
        [GreaterThanOrEqualTo("MinFootage", ErrorMessage = "MinFootage should be <= MaxFootage")]
        public int MaxFootage { get; set; }
        
        public AdvertTypeDomainModel AdvertType { get; set; }
    }
}
