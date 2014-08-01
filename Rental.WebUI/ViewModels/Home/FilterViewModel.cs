using System.ComponentModel.DataAnnotations;
using Foolproof;
using Rental.WebUI.ViewModels.Enums;

namespace Rental.WebUI.ViewModels.Home
{
    public class FilterViewModel
    {
        public FilterViewModel()
        {
            MinPrice = 0;
            MaxPrice = 20000;
            MinFootage = 0;
            MaxFootage = 20000;
            AdvertType = AdvertTypeViewModel.None;
        }

        [DataType(DataType.Currency, ErrorMessage = "{0} has wrong format")]
        [Range(typeof(decimal), "0", "20000", ErrorMessage = "{0} is out of range")]
        public decimal MinPrice { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "{0} has wrong format")]
        [Range(typeof(decimal), "0", "20000", ErrorMessage = "{0} is out of range")]
        [GreaterThanOrEqualTo("MinPrice", ErrorMessage = "MinPrice should be <= MaxPrice")]
        public decimal MaxPrice { get; set; }

        [Range(0, 20000, ErrorMessage = "{0} is out of range")]
        public int MinFootage { get; set; }

        [Range(0, 20000, ErrorMessage = "{0} is out of range")]
        [GreaterThanOrEqualTo("MinFootage", ErrorMessage = "MinFootage should be <= MaxFootage")]
        public int MaxFootage { get; set; }

        public AdvertTypeViewModel AdvertType { get; set; }
    }
}