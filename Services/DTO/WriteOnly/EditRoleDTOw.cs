using System.ComponentModel.DataAnnotations;

namespace Address_Book.Services.DTO.WriteOnly
{
    public class EditRoleDTOw
    {
        public EditRoleDTOw()
        {
            Users = new List<string>();
        }
        public string? Id { get; set; }

        [Required(ErrorMessage = "Role Name is Required")]
        public string? RoleName { get; set; }

        public List<string>? Users { get; set; }
    }
}
