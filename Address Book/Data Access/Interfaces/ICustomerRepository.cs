namespace Address_Book.Models
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> CustomersList();
        Customer GetCustomer(int id);
        Customer Create(Customer customer);
        Customer Update(Customer customerChanges);
        Customer Delete(int id);
    }
}
