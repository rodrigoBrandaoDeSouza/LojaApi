using LojaApi.Domain.Entities;
using MediatR;

namespace LojaApi.Application.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }

        public Order ToOrder()
        {
            return new Order { 
                OrderNumber = OrderNumber, 
                OrderDate = OrderDate 
            };
        }
    }
}
