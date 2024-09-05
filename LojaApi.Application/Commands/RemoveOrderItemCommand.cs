using LojaApi.Domain.Entities;
using MediatR;

namespace LojaApi.Application.Commands
{
    public class RemoveOrderItemCommand : IRequest<string>
    {
        public Guid OrderId { get; set; }
        public OrderItem OrderItem { get; set; } = new OrderItem();
    }
}
