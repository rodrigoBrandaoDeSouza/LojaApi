using LojaApi.Domain.Entities;

namespace LojaApi.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Guid> InsertOrderAsync(Order order);
    }
}
