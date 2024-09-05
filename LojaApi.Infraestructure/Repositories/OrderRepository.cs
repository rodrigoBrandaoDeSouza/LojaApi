using LojaApi.Domain.Entities;
using LojaApi.Domain.Interfaces;
using LojaApi.Infraestructure.Context;

namespace LojaApi.Infraestructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LojaApiDbContext _dbContext;

        public OrderRepository(LojaApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> InsertOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order.OrderId;
        }
    }
}
