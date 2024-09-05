using LojaApi.Domain.Entities;
using MediatR;

namespace LojaApi.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<Order>
    {
        public GetOrderByIdQuery() { }

        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; set; }
    }
}
