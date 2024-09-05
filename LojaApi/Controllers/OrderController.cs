using LojaApi.Application.Commands;
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

        [HttpPost(Name = "CreateOrder")]
        [SwaggerOperation(Summary = "Insert a order into database")]
        public async Task<Guid> CreateOrder([FromBody] CreateOrderCommand createOrderCommand)
        {
            return await _mediator.Send(createOrderCommand);
        }
    }
}
