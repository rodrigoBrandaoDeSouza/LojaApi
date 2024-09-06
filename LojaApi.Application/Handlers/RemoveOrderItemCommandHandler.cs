using LojaApi.Application.Commands;
using LojaApi.Domain.Constants;
using LojaApi.Domain.Entities;
using LojaApi.Domain.Interfaces;
using MediatR;

namespace LojaApi.Application.Handlers
{
    public class RemoveOrderItemCommandHandler : IRequestHandler<RemoveOrderItemCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public RemoveOrderItemCommandHandler(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<string> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            OrderItem orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemId);

            Order order = await _orderRepository.GetOrderByIdAsync(orderItem.OrderId);

            if (order == null || orderItem == null)
            {
                return Mensagens.PedidoInexistente;
            }

            await _orderItemRepository.DeleteOrderItemAsync(orderItem);

            return Mensagens.ProdutoRemovidoComSucesso;
        }
    }
}
