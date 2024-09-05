using LojaApi.Application.Commands;
using LojaApi.Domain.Constants;
using LojaApi.Domain.Entities;
using LojaApi.Domain.Enums;
using LojaApi.Domain.Interfaces;
using MediatR;

namespace LojaApi.Application.Handlers
{
    public class CloseOrderCommandHandler : IRequestHandler<CloseOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;

        public CloseOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<string> Handle(CloseOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            if (order == null)
            {
                return Mensagens.PedidoInexistente;
            }

            if (order.OrderStatus == OrderStatusEnum.Closed)
            {
                return Mensagens.PedidoJaFechado;
            }

            if (!order.OrderItens.Any())
            {
                return Mensagens.PedidoNaoContemItens;
            }

            order.OrderStatus = OrderStatusEnum.Closed;

            await _orderRepository.UpdateOrderAsync(order);

            return Mensagens.PedidoFechadoComSucesso;
        }
    }
}
