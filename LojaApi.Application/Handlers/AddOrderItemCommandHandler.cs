using LojaApi.Application.Commands;
using LojaApi.Domain.Constants;
using LojaApi.Domain.Entities;
using LojaApi.Domain.Interfaces;
using MediatR;

namespace LojaApi.Application.Handlers
{
    public class AddOrderItemCommandHandler : IRequestHandler<AddOrderItemCommand, string>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderItemCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<string> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await _orderRepository.GetOrderByIdAsync(request.OrderId);

                if (order == null)
                {
                    return Mensagens.PedidoInexistente;
                }

                order.OrderItens.Add(new OrderItem(request.Quantity));

                await _orderRepository.UpdateOrderAsync(order);

                return Mensagens.ProdutoAdicionadoComSucesso;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
