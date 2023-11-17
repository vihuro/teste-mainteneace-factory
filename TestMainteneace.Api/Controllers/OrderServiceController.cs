using MediatR;
using Microsoft.AspNetCore.Mvc;
using TesteMainteneace.Application.UseCases.OrderService;
using TesteMainteneace.Application.UseCases.OrderService.CreateOrderService;
using TesteMainteneace.Application.UseCases.OrderService.GetAllOrderService;

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
        /// <summary>
        /// Criar uma nova ordem de serviço
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
        /// Buscar todas ordens de serviço
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
    }
}
