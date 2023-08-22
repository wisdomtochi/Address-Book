using System.ComponentModel.DataAnnotations;

namespace Address_Book.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone Number:")]
        public int PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
