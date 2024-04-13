using Address_Book.Services.Administration.Interface;
using Address_Book.Services.ViewModels;

namespace Address_Book.Services.Administration.Implementation
{
    public class AdminService : IAdminService
    {
        public (bool status, string message) CreateRole(CreateRoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public (bool status, string message) DeleteRole(string id)
        {
            throw new NotImplementedException();
        }

        public (bool status, string message) EditRole(string id)
        {
            throw new NotImplementedException();
        }
    }
}
