

using DriverRepository.Model;
using Microsoft.EntityFrameworkCore;

namespace DriverRepository.ContextFile
{
    public class DriverContext : DbContext
    {
        public DriverContext() { }
        public DriverContext(DbContextOptions<DriverContext> options) : base(options)
        {
        }

        public virtual DbSet<Driver> Driver { get; set; }

    }
}
