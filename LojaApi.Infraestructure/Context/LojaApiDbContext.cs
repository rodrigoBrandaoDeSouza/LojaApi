using LojaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Infraestructure.Context
{
    public class LojaApiDbContext : DbContext
    {
        public LojaApiDbContext(DbContextOptions<LojaApiDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LojaApiOnMemory");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasMany(x => x.OrderItens).WithOne().HasForeignKey(z => z.OrderId);
        }
    }
}
