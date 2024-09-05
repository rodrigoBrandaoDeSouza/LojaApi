using LojaApi.Application.Commands;
using LojaApi.Application.Queries;
using LojaApi.Application.Queries.Orders;
using LojaApi.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LojaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateOrder")]
        [SwaggerOperation(Summary = "Creater a new order")]
        public async Task<Guid> CreateOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            return await _mediator.Send(createOrderCommand);
        }

        [HttpPost("CloseOrder")]
        [SwaggerOperation(Summary = "Change the order status to Closed")]
        public async Task<string> CloseOrder([FromBody] CloseOrderCommand closeOrderCommand)
        {
            return await _mediator.Send(closeOrderCommand);
        }

        [HttpPost("AddOrderItem")]
        [SwaggerOperation(Summary = "Add a order item into a order ")]
        public async Task<string> AddOrderItem([FromBody] AddOrderItemCommand addOrderItemCommand)
        {
            return await _mediator.Send(addOrderItemCommand);
        }

        [HttpPost("RemoveOrderItem")]
        [SwaggerOperation(Summary = "Remove a item from a order")]
        public async Task<string> RemoveOrderItem([FromBody] RemoveOrderItemCommand removeOrderItemCommand)
        {
            return await _mediator.Send(removeOrderItemCommand);
        }

        [HttpGet("GetAllOrders")]
        [SwaggerOperation(Summary = "Retrieve all orders")]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            GetAllOrdersQuery request = new GetAllOrdersQuery();

            return await _mediator.Send(request);
        }

        [HttpGet("GetOrderById")]
        [SwaggerOperation(Summary = "Retrieve a order by id")]
        public async Task<Order> GetOrderById([FromQuery] Guid orderId)
        {
            return await _mediator.Send(new GetOrderByIdQuery(orderId));
        }
    }
}
