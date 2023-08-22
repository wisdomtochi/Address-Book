using Address_Book.Data_Access.Interfaces;
using Address_Book.DTO.Read;
using Address_Book.DTO.Write;
using Address_Book.Models;
using Address_Book.Services.Interfaces;

namespace Address_Book.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly Data_Access.Interfaces.IGenericRepository<Customer> customerGenericRepository;

        public CustomerService(IGenericRepository<Customer> customerGenericRepository)
        {
            this.customerGenericRepository = customerGenericRepository;
        }

        public async Task<int> CreateCustomer(CustomerCreateViewModel model)
        {
            Customer newCustomer = new()
            {
                Name = model.Name,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };
            var customer = await customerGenericRepository.Create(newCustomer);
            await customerGenericRepository.SaveAsync();
            return customer.Id;
        }

        public async Task DeleteCustomer(int customerId)
        {
            Customer customer = await customerGenericRepository.ReadSingle(customerId);
            await customerGenericRepository.Delete(customer.Id);
            await customerGenericRepository.SaveAsync();
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            Customer customer = await customerGenericRepository.ReadSingle(customerId);
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetCustomerList()
        {
            return await customerGenericRepository.ReadAll();
        }

        public async Task UpdateCustomer(CustomerEditViewModel model)
        {
            try
            {
                Customer customer = await customerGenericRepository.ReadSingle(model.Id);
                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.DateOfBirth = model.DateOfBirth;
                customer.Address = model.Address;
                customer.PhoneNumber = model.PhoneNumber;
                customerGenericRepository.Update(customer);
                await customerGenericRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
