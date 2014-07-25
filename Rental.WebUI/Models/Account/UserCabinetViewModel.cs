using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rental.WebUI.Models.Account
{
    public class UserCabinetViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}