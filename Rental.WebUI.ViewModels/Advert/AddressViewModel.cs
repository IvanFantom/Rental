using System.ComponentModel.DataAnnotations;

namespace Rental.WebUI.ViewModels.Advert
{
    public class AddressViewModel
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string Street { get; set; }
    }
}