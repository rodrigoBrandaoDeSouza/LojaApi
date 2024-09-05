using LojaApi.Domain.Entities;
using LojaApi.Domain.Interfaces;
using LojaApi.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Infraestructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LojaApiDbContext _dbContext;

        public OrderRepository(LojaApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task UpdateOrderAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == orderId);
        }

        public async Task<Guid> InsertOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order.OrderId;
        }

        public Task<List<Order>> GetAllAsync()
        {
            var teste = _dbContext.Orders.ToListAsync();

            return teste;
        }
    }
}
