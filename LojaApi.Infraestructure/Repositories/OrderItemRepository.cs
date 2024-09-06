using LojaApi.Domain.Entities;
using LojaApi.Domain.Interfaces;
using LojaApi.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Infraestructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly LojaApiDbContext _dbContext;

        public OrderItemRepository(LojaApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteOrderItemAsync(OrderItem orderItem)
        {
            _dbContext.OrderItems.Remove(orderItem);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<OrderItem> GetByIdAsync(Guid orderItemId)
        {
            return await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.Id == orderItemId);
        }
    }
}
