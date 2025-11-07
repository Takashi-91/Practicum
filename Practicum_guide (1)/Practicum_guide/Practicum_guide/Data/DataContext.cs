using ECommerceClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Practicum_guide.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
