

using IdentityRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace IdentityRepository.ContextFile
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() { }
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }

    }
}
