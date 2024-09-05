using LojaApi.Domain.Entities;

namespace LojaApi.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Guid> InsertOrderAsync(Order order);

        Task<Order> GetOrderByIdAsync(Guid orderId);

        Task UpdateOrderAsync(Order order);

        Task<List<Order>> GetAllAsync();
    }
}
