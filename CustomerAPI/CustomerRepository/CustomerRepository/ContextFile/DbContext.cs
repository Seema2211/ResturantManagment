using CustomerRepository.Model;
using Microsoft.EntityFrameworkCore;


namespace CustomerRepository.ContextFile
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() { }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }

    }
}
