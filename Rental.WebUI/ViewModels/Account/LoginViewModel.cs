using System.ComponentModel.DataAnnotations;

namespace Rental.WebUI.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}