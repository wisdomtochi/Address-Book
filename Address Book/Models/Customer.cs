using System.ComponentModel.DataAnnotations;

namespace Address_Book.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Phone Number:")]
        public int PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
