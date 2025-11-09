using Library.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> opts) : base(opts) { }

        public DbSet<OrderEvent> OrderEvents => Set<OrderEvent>();

        public DbSet<ProcessedOrder> ProcessedOrders => Set<ProcessedOrder>();


       
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<OrderEvent>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasKey(x => x.OrderId);
            });
            mb.Entity<ProcessedOrder>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasKey(x => x.OrderId);
            });
        }
    }
}

