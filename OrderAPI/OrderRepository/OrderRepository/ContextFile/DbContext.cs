

using Microsoft.EntityFrameworkCore;
using OrderRepository.Model;

namespace OrderRepository.ContextFile
{
    public class OrderContext : DbContext
    {
        public OrderContext() { }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public virtual DbSet<Order> Order { get; set; }

    }
}
