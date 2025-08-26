using System.ComponentModel.DataAnnotations;

namespace SmartTrack.Models
{
    public class RegisterViewModel
    {
        [Required, Display(Name = "Full Name")]
        public required string FullName { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, DataType(DataType.Password), MinLength(6)]
        public required string Password { get; set; }

        [Required, DataType(DataType.Password),
         Compare("Password", ErrorMessage = "Passwords do not match")]
        [Display(Name = "Confirm Password")]
        
        public required string ConfirmPassword { get; set; } 
    }
}
