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

        [DataType(DataType.Currency)]
        [Range(0,20000,ErrorMessage = "it should be in range is 0..{2}")]
        public decimal MinPrice { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 20000, ErrorMessage = "it should be in range is 0..{2}")]
        [GreaterThanOrEqualTo("MinPrice", ErrorMessage = "MinPrice should be <= MaxPrice")]
        public decimal MaxPrice { get; set; }

        [RegularExpression("[0-9]{1,}", ErrorMessage = "it should be positive integer")]
        [Range(0, 20000, ErrorMessage = "it should be in range is 0..{2}")]
        public int MinFootage { get; set; }

        [RegularExpression("[0-9]{1,}", ErrorMessage = "it should be positive integer")]
        [Range(0, 20000, ErrorMessage = "it should be in range is 0..{2}")]
        [GreaterThanOrEqualTo("MinFootage", ErrorMessage = "MinFootage <= MaxFootage")]
        public int MaxFootage { get; set; }

        public AdvertTypeViewModel AdvertType { get; set; }
    }
}