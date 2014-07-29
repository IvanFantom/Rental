using System.ComponentModel.DataAnnotations;

namespace Rental.WebUI.ViewModels.Account
{
    public class EditUserViewModel
    {
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}