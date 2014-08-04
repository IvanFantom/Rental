using System.ComponentModel.DataAnnotations;
using Rental.WebUI.ViewModels.Enums;

namespace Rental.WebUI.ViewModels.Advert
{
    public class AdvertViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Header { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "20000", ErrorMessage = "{0} is out of range")]
        public decimal Price { get; set; }
        
        [Required]
        [Range(0, 20000, ErrorMessage = "{0} is out of range")]
        public int Footage { get; set; }

        public bool IsReserved { get; set; }

        [Required]
        [Display(Name = "Type")]
        public AdvertTypeViewModel Type { get; set; }

        [Required]
        public AddressViewModel Address { get; set; }

        public string UserId { get; set; }

        public string ReservatorId { get; set; }
    }
}