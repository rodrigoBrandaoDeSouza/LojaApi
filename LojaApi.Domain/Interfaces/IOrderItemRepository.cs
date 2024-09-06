using LojaApi.Domain.Entities;

namespace LojaApi.Domain.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetByIdAsync(Guid orderItemId);
        Task DeleteOrderItemAsync(OrderItem orderItem);

    }
}
