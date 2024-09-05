using LojaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Infraestructure.Context
{
    public class LojaApiDbContext : DbContext
    {
        public LojaApiDbContext(DbContextOptions<LojaApiDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LojaApiOnMemory");
        }
    }
}
