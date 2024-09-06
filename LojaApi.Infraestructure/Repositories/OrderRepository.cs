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

        public async Task AddOrderItemAsync(Order order, OrderItem orderItem)
        {
            order.OrderItens.Add(orderItem);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return await _dbContext.Orders.Include(z=> z.OrderItens)
                .FirstOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<Guid> InsertOrderAsync(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order.Id;
        }

        public Task<List<Order>> GetAllAsync()
        {
            return _dbContext.Orders
                .Include(z => z.OrderItens)
                .ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
