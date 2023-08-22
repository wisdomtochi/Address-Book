using Address_Book.DTO.Read;
using Address_Book.DTO.Write;
using Address_Book.Models;

namespace Address_Book.Services.Interfaces
{
    public interface ICustomerService
    {
        Task UpdateCustomer(CustomerEditViewModel model);

        Task<int> CreateCustomer(CustomerCreateViewModel model);

        Task<Customer> GetCustomer(int customerId);

        Task<IEnumerable<Customer>> GetCustomerList();

        Task DeleteCustomer(int customerId);
    }
}
