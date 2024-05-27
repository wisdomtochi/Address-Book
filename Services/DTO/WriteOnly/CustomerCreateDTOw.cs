using System.ComponentModel.DataAnnotations;

namespace Address_Book.Services.DTO.WriteOnly
{
    public class CustomerCreateDTOw
    {
        [Key]
        public Guid CustomerId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone Number: ")]
        [MaxLength(25)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
