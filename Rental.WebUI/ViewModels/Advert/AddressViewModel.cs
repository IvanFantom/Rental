using System.ComponentModel.DataAnnotations;

namespace Rental.WebUI.ViewModels.Advert
{
    public class AddressViewModel
    {
        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string Country { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string City { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string District { get; set; }

        [Required]
        [StringLength(128, ErrorMessage = "The {0} must be no more than {1} characters")]
        public string Street { get; set; }
    }
}