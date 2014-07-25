using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Rental.Models.Enums;
using Rental.Models.Entities;

namespace Rental.WebUI.Models.Advert
{
    public class AdvertViewModel
    {
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
        public AdvertType AdvertType { get; set; }

        [Required]
        public AddressViewModel Address { get; set; }
    }
}