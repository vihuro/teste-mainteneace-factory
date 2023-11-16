using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.OrderService;
using TesteMainteneace.Application.UseCases.OrderService.CreateOrderService;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/order-service")]
    public class OrderServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<OrderServiceResponseDefault>> Create(CreateOrderServiceRequest request, 
                                                                            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Created("", result);
        }
    }
}
