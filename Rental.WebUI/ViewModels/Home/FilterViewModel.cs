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

        [Display(Name = "Min Price")]
        [DataType(DataType.Currency, ErrorMessage = "{0} has wrong format")]
        [Range(typeof(decimal), "0", "20000", ErrorMessage = "{0} is out of range")]
        [LessThanOrEqualTo("MaxPrice", ErrorMessage = "{0} should be less than or equal to {1}")]
        public decimal MinPrice { get; set; }

        [Display(Name = "Max Price")]
        [DataType(DataType.Currency, ErrorMessage = "{0} has wrong format")]
        [Range(typeof(decimal), "0", "20000", ErrorMessage = "{0} is out of range")]
        [GreaterThanOrEqualTo("MinPrice", ErrorMessage = "{0} should be greater than or equal to {1}")]
        public decimal MaxPrice { get; set; }

        [Display(Name = "Min Footage")]
        [Range(0, 20000, ErrorMessage = "{0} is out of range")]
        [LessThanOrEqualTo("MaxFootage", ErrorMessage = "{0} should be greater than or equal to {1}")]
        public int MinFootage { get; set; }

        [Display(Name = "Max Footage")]
        [Range(0, 20000, ErrorMessage = "{0} is out of range")]
        [GreaterThanOrEqualTo("MinFootage", ErrorMessage = "{0} should be greater than or equal to {1}")]
        public int MaxFootage { get; set; }

        [Display(Name = "Type")]
        public AdvertTypeViewModel AdvertType { get; set; }
    }
}