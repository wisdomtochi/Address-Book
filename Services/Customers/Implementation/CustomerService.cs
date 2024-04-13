using Address_Book.Data.DataAccess.Interfaces;
using Address_Book.Domain;
using Address_Book.Services.Customers.Interfaces;
using Address_Book.Services.ViewModels;

namespace Address_Book.Services.Customers.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> customerGenericRepository;

        public CustomerService(IGenericRepository<Customer> customerGenericRepository)
        {
            this.customerGenericRepository = customerGenericRepository;
        }

        public async Task<Customer> CreateCustomer(CustomerCreateViewModel model)
        {
            Customer customer = new()
            {
                Name = model.Name,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };
            await customerGenericRepository.Create(customer);
            await customerGenericRepository.SaveAsync();
            return customer;
        }

        public async Task DeleteCustomer(int Id)
        {
            Customer customer = await customerGenericRepository.ReadSingle(Id);

            await customerGenericRepository.Delete(customer.Id);
            await customerGenericRepository.SaveAsync();
        }

        public async Task<Customer> GetCustomer(int Id)
        {
            Customer customer = await customerGenericRepository.ReadSingle(Id);

            return customer;

        }

        public async Task<List<Customer>> GetCustomerList()
        {
            var customers = await customerGenericRepository.ReadAll();

            return customers.ToList();
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
