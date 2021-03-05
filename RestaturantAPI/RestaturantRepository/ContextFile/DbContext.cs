

using Microsoft.EntityFrameworkCore;
using RestaturantRepository.Model;
using RestaturantRepository.Repository;

namespace RestaturantRepository.ContextFile
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext() { }
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }

    }
}
