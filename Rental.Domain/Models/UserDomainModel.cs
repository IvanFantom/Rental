using System.ComponentModel.DataAnnotations;

namespace Rental.Domain.Models
{
    public class UserDomainModel
    {
        public string Id { get; set; }

        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string UserName { get; set; }

        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(64, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string LastName { get; set; }

        [StringLength(128, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [EmailAddress(ErrorMessage = "The {0} has wrong format")]
        public string Email { get; set; }
    }
}