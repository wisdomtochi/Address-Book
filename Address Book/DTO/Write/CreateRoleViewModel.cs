using System.ComponentModel.DataAnnotations;

namespace Address_Book.DTO.Write
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
