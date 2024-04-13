using System.ComponentModel.DataAnnotations;

namespace Address_Book.Services.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
