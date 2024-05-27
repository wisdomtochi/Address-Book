﻿using System.ComponentModel.DataAnnotations;

namespace Address_Book.Domain
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
