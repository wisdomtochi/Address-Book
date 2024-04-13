using Address_Book.Domain;
using Address_Book.Services.ViewModels;

namespace Address_Book.Services.Customers.Interfaces
{
    public interface ICustomerService
    {
        Task UpdateCustomer(CustomerEditViewModel model);

        Task<Customer> CreateCustomer(CustomerCreateViewModel model);

        Task<Customer> GetCustomer(int Id);

        Task<List<Customer>> GetCustomerList();

        Task DeleteCustomer(int Id);
    }
}
