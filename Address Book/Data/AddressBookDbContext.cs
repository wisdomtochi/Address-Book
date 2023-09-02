using Address_Book.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Address_Book.Data
{
    public class AddressBookDbContext : IdentityDbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }

        public void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}
