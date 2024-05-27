using Address_Book.Data.DataAccess.Interfaces;
using Address_Book.Domain;
using Address_Book.Services.Customers.Interfaces;
using Address_Book.Services.DTO.WriteOnly;

namespace Address_Book.Services.Customers.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> customerGenericRepository;

        public CustomerService(IGenericRepository<Customer> customerGenericRepository)
        {
            this.customerGenericRepository = customerGenericRepository;
        }

        public async Task<Customer> CreateCustomer(CustomerCreateDTOw model)
        {
            Customer customer = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateOfBirth = model.DateOfBirth,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };
            await customerGenericRepository.Create(customer);
            await customerGenericRepository.SaveAsync();
            return customer;
        }

        public async Task DeleteCustomer(Guid Id)
        {
            Customer customer = await customerGenericRepository.ReadSingle(Id);

            await customerGenericRepository.Delete(customer.Id);
            await customerGenericRepository.SaveAsync();
        }

        public async Task<Customer> GetCustomer(Guid Id)
        {
            Customer customer = await customerGenericRepository.ReadSingle(Id);

            return customer;

        }

        public async Task<List<Customer>> GetCustomerList()
        {
            var customers = await customerGenericRepository.ReadAll();

            return customers.ToList();
        }

        public async Task UpdateCustomer(CustomerEditDTOw model)
        {
            try
            {
                Customer customer = await customerGenericRepository.ReadSingle(model.Id);
                customer.FirstName = model.FirstName;
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
