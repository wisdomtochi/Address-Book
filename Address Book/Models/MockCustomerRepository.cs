namespace Address_Book.Models
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customerList;

        public MockCustomerRepository()
        {
            _customerList = new List<Customer>()
            {
                new Customer(){Id = 1, Name ="James", Address="2, Muyibi Street Olodi Apapa, Lagos", DateOfBirth=new DateOnly(2022,3,1), Email="james@wisdomdev.com", PhoneNumber=222222222}
            };
        }

        public IEnumerable<Customer> CustomersList()
        {
            return _customerList;
        }

        public Customer GetCustomer(int id)
        {
            return _customerList.FirstOrDefault(e => e.Id == id);
        }

        public Customer Add(Customer customer)
        {
            customer.Id = _customerList.Max(e => e.Id) + 1;
            _customerList.Add(customer);
            return customer;
        }

        public Customer Update(Customer customerChanges)
        {
            Customer customer = _customerList.FirstOrDefault(e => e.Id == customerChanges.Id);
            if (customer != null)
            {
                customer.Name = customerChanges.Name;
                customer.Email = customerChanges.Email;
                customer.DateOfBirth = customerChanges.DateOfBirth;
                customer.Address = customerChanges.Address;
                customer.PhoneNumber = customerChanges.PhoneNumber;
            }
            return customer;
        }

        public Customer Delete(int id)
        {
            Customer customer = _customerList.FirstOrDefault(e => e.Id == id);
            if (customer != null)
            {
                _customerList.Remove(customer);
            }
            return customer;
        }
    }
}
