using QuickBuck.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace QuickBuck.DTOs
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage ="Email address has been inserted incorrectly")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage ="Phone is required")]
        [Phone(ErrorMessage ="Phone is Incorrect")]
        public string Phone { get; set; }
        
        public Address Address { get; set; } 
        public JobProviderDTO? JobProvider { get; set; }
        public JobSeekerDTO? JobSeeker { get; set; }
        
    }
}
