using Address_Book.Domain;
using Address_Book.Services.DTO.WriteOnly;

namespace Address_Book.Services.Customers.Interfaces
{
    public interface ICustomerService
    {
        Task UpdateCustomer(CustomerEditDTOw model);

        Task<Customer> CreateCustomer(CustomerCreateDTOw model);

        Task<Customer> GetCustomer(Guid Id);

        Task<List<Customer>> GetCustomerList();

        Task DeleteCustomer(Guid Id);
    }
}
