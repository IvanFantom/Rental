using System.ComponentModel.DataAnnotations;

namespace Rental.WebUI.ViewModels.Account
{
    public class EditUserViewModel
    {
        [Display(Name = "First Name")]
        [StringLength(64, ErrorMessage = "should be from {2} to {1} long", MinimumLength = 0)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(64, ErrorMessage = "should be from {2} to {1} long", MinimumLength = 0)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}