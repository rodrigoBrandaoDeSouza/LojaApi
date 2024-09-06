using LojaApi.Application.Commands;
using LojaApi.Domain.Constants;
using LojaApi.Domain.Entities;
using LojaApi.Domain.Interfaces;
using MediatR;

namespace LojaApi.Application.Handlers
{
    public class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, string>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;


        public AddOrderItemCommandHandler(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        public async Task<string> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

            if (order == null)
            {
                return Mensagens.PedidoInexistente;
            }

            OrderItem orderItem = new OrderItem()
            {
                OrderId = request.OrderId,
                Quantity = request.Quantity,
            };

            await _orderRepository.AddOrderItemAsync(order, orderItem);

            return Mensagens.ProdutoAdicionadoComSucesso;

        }
    }
}
