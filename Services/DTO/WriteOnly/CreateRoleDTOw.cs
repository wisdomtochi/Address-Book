using System.ComponentModel.DataAnnotations;

namespace Address_Book.Services.DTO.WriteOnly
{
    public class CreateRoleDTOw
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
