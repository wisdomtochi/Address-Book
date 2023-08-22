using Address_Book.Data;

namespace Address_Book.Models
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly AddressBookDbContext context;

        public SQLCustomerRepository(AddressBookDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> CustomersList()
        {
            return context.Customers;
        }

        public Customer GetCustomer(int id)
        {
            return context.Customers.Find(id);
        }

        public Customer Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return customer;
        }

        public Customer Update(Customer customerChanges)
        {
            var customer = context.Customers.Attach(customerChanges);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return customerChanges;
        }

        public Customer Delete(int id)
        {
            Customer customer = context.Customers.Find(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                context.SaveChanges();
            }
            return customer;
        }
    }
}
