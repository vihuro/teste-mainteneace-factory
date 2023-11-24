using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.OrderService;
using TesteMainteneace.Application.UseCases.OrderService.CreateOrderService;
using TesteMainteneace.Application.UseCases.OrderService.GetAllOrderService;
using TesteMainteneace.Application.UseCases.OrderService.GetById;

namespace TestMainteneace.Api.Controllers
{
    [ApiController]
    [Route("api/v1/order-service")]
    [Produces("application/json")]
    public class OrderServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Create a order service
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// 
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OrderServiceResponseDefault>> Create(CreateOrderServiceRequest request,
                                                                            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(request, cancellationToken);

            return Created("", result);
        }
        /// <summary>
        /// Search list orders service
        /// </summary>
        /// 
        /// <param name="cancellationToken"></param>
        /// 
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<OrderServiceResponseDefault>>> GetList(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllOrderServiceRequest(), cancellationToken);

            return result;
        }
        /// <summary>
        /// Search order service by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// 
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderServiceResponseDefault>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetByIdRequest(id), cancellationToken);

            if (result == null) return NotFound("Order not found!");

            return Ok(result);
        }
    }
}
