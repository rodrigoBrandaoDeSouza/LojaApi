using LojaApi.Domain.Entities;
using MediatR;

namespace LojaApi.Application.Queries.Orders
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<Order>>
    {

    }
}
