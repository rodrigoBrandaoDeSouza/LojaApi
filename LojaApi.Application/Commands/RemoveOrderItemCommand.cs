using LojaApi.Domain.Entities;
using MediatR;

namespace LojaApi.Application.Commands
{
    public class RemoveOrderItemCommand : IRequest<string>
    {
        public Guid OrderItemId { get; set; }
    }
}
