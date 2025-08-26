using System.ComponentModel.DataAnnotations;
using System.Drawing.Imaging;

namespace SmartTrack.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Please enter First Name")]
        public string FirstName { get; set; } = string.Empty;

        public String? MiddleName { get; set; }
        [Required(ErrorMessage = "Please enter Last Name")]
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName}{MiddleName}{LastName} ";
        [EmailAddress]
        [Required(ErrorMessage = "Please enter Email Address")]
        public String EmailAddress { get; set; } = string.Empty;
        [Phone]
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        public string Department { get; set; } = string.Empty;
        [Required]
        public string Designation { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
    }
}
