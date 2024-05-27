using Address_Book.Services.Helpers;

namespace Address_Book.Services.Administration.Interface
{
    public interface IAdminService
    {
        Task<bool> IsEmailInUse(string email);
        Task<Result> Register(string firstname, string lastname, string email, string password);
        Task<Result> Login(string email, string password, bool rememberMe);
        Task Logout();
    }
}
