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

        public RemoveOrderItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<string> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            if (order == null)
            {
                return Mensagens.PedidoInexistente;
            }

            order.OrderItens.Remove(request.OrderItem);

            await _orderRepository.UpdateOrderAsync(order);

            return Mensagens.ProdutoRemovidoComSucesso;
        }
    }
}
