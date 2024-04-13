using Address_Book.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Address_Book.Data.DataContext
{
    public class AddressBookDbContext : IdentityDbContext
    {
        public AddressBookDbContext(DbContextOptions<AddressBookDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => base.OnModelCreating(modelBuilder);
    }
}
