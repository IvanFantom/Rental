using System.ComponentModel.DataAnnotations;

namespace Rental.WebUI.ViewModels.Account
{
    public class EditUserViewModel
    {
        [Display(Name = "First Name")]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "The {0} has wrong format")]
        public string Email { get; set; }
    }
}