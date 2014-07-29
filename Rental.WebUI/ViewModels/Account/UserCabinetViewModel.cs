using System.ComponentModel.DataAnnotations;

namespace Rental.WebUI.ViewModels.Account
{
    public class UserCabinetViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}