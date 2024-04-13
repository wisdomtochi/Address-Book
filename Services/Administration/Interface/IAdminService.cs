using Address_Book.Services.ViewModels;

namespace Address_Book.Services.Administration.Interface
{
    public interface IAdminService
    {
        (bool status, string message) CreateRole(CreateRoleViewModel model);
        (bool status, string message) EditRole(string id);
        (bool status, string message) DeleteRole(string id);

    }
}
