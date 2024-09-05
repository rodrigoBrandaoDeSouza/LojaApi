using MediatR;

namespace LojaApi.Application.Commands
{
    public class CloseOrderCommand : IRequest<string>
    {
        public Guid OrderId { get; set; }

    }
}
