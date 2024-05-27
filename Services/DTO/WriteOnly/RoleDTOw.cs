using Address_Book.Services.DTO.ReadOnly;

namespace Address_Book.Services.DTO.WriteOnly
{
    public class RoleDTOw
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<UsersInRoleDTO> UsersInRoles { get; set; }
    }
}
