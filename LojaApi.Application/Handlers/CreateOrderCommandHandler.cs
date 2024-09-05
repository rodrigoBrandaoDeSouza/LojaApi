using LojaApi.Application.Commands;
using LojaApi.Domain.Interfaces;
using MediatR;

namespace LojaApi.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return await _orderRepository.InsertOrderAsync(request.ToOrder());
        }
    }
}
