using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Address_Book.Services.Models
{
    public class AddressBookUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Email { get; set; }
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match.")]
        public string ConfirmPassWord { get; set; }
    }
}
