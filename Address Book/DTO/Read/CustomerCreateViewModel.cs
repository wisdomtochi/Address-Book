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
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Phone Number: ")]
        //[StringLength(11, ErrorMessage = "Phone Number length must equal to 10")]
        public int PhoneNumber { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
