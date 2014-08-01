using System.ComponentModel.DataAnnotations;
using Rental.WebUI.ViewModels.Enums;

namespace Rental.WebUI.ViewModels.Advert
{
    public class AdvertViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "The header should be no more than {0} characters long.")]
        public string Header { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int Footage { get; set; }     
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Type")]
        public AdvertTypeViewModel Type { get; set; }

        [Required]
        public AddressViewModel Address { get; set; }

        public string UserId { get; set; }
    }
}