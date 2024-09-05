using LojaApi.Domain.Entities;
using MediatR;

namespace LojaApi.Application.Commands
{
    public class AddOrderItemCommand : IRequest<string>
    {
        public Guid OrderId { get; set; }
        public int Quantity{ get; set; }
    }
}
