using System.ComponentModel.DataAnnotations;

namespace Address_Book.DTO.Read
{
    public class CustomerCreateViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        //[MinLength(11, ErrorMessage = "Address cannot be less than 11 characters")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Phone Number: ")]
        //[MaxLength(13, ErrorMessage = "Phone Number length must equal to 11")]
        public int PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
